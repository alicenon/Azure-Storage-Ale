using Microsoft.WindowsAzure.Storage.File;
using Microsoft.WindowsAzure.Storage;
namespace _01AzureStorageFilesAlejandro
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async  void btnLeer_Click(object sender, EventArgs e)
        {
            //PRIMERO NECESITAMOS LEER LA CLAVE DE ACCESO A STORAGE
            string key = "DefaultEndpointsProtocol=https;AccountName=storagecursoalejandromon;AccountKey=S1JtllbiIzHCYRUoFZudxrkd/FfScqRdKU5ttprkojIzc0pkGkd9RTsYZqVg0twiw+25Nm8wa0+Z+ASt6+dMiA==;EndpointSuffix=core.windows.net";
            CloudStorageAccount account = CloudStorageAccount.Parse(key);

            //PARA ACCEDER A UN RECURSO SE DEBE HACER MEDIANTE UN CLIENTE ESPECIALIZADO
            CloudFileClient client = account.CreateCloudFileClient();
            
            //DEBEMOS ACCEDER AL RECURDO (SHARED) COMPARTIDO QUE HEMOS CREADO EN STORAGE FILE
            CloudFileShare fileShare = client.GetShareReference("ficherosuwu");

            //LOS FICHEROS LOS TENEMOS DIRECTAMENTE EN LA RAIZ DEL SHARED
            CloudFileDirectory raiz = fileShare.GetRootDirectoryReference();
            CloudFile file = raiz.GetFileReference("NoticiasUwU.txt");

            String contenido =  await file.DownloadTextAsync();
            this.txtcontenido.Text = contenido;
        }
    }
}
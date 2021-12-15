using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

class AzureService
{
    private const string CADENA_CONEXION = "DefaultEndpointsProtocol=https;AccountName=tema5actv;AccountKey=WgBtaSmm4rm3UjhYUqq33T6RG8oJt1R6/HlcgoViPlnwaO3/nkLgCLHJmOdPynrPoFFKg6064sC71r2vHwizag==;EndpointSuffix=core.windows.net";
    private const string CONTENEDOR = "actividad5imagenessandra";

    string cadenaConexion = CADENA_CONEXION; //La obtenemos en el portal de Azure, asociada a la cuenta de almacenamiento
    string nombreContenedorBlobs = CONTENEDOR; //El nombre que le hayamos dado a nuestro contenedor de blobs en el portal de Azure

    public string SubirImagen(string rutaImagen)
    {
        //Obtenemos el cliente del contenedor
        var clienteBlobService = new BlobServiceClient(cadenaConexion);
        var clienteContenedor = clienteBlobService.GetBlobContainerClient(nombreContenedorBlobs);

        //Leemos la imagen y la subimos al contenedor
        Stream streamImagen = File.OpenRead(rutaImagen);
        string nombreImagen = Path.GetFileName(rutaImagen);
        clienteContenedor.UploadBlob(nombreImagen, streamImagen);

        //Una vez subida, obtenemos la URL para referenciarla
        var clienteBlobImagen = clienteContenedor.GetBlobClient(nombreImagen);
        string urlImagen = clienteBlobImagen.Uri.AbsoluteUri;
        return urlImagen;
    }
    
}


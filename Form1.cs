using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using Newtonsoft.Json;


namespace Archivos_XML_JSON
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            // Abrir un cuadro de diálogo para seleccionar un archivo XML o JSON
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos XML (*.xml)|*.xml|Archivos JSON (*.json)|*.json";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string fileContent = File.ReadAllText(filePath); // Leer el contenido del archivo

                // Mostrar el contenido del archivo en el TextBox
                txtContenido.Text = fileContent;

                // Determinar el tipo de archivo (XML o JSON) basado en la extensión del archivo
                if (filePath.EndsWith(".xml"))
                {
                    // Procesamiento de archivos XML
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(filePath); // Cargar el archivo XML en un objeto XmlDocument
                    
                }
                else if (filePath.EndsWith(".json"))
                {
                    // Procesamiento de archivos JSON
                    dynamic jsonContent = JsonConvert.DeserializeObject(fileContent); // Deserializar el JSON
                    
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Abrir un cuadro de diálogo para guardar el archivo
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivos XML (*.xml)|*.xml|Archivos JSON (*.json)|*.json";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                // Guardar el contenido del TextBox en el archivo
                File.WriteAllText(filePath, txtContenido.Text);
                MessageBox.Show("Archivo guardado exitosamente.");

                // Verificar la extensión del archivo y realizar operaciones adicionales según sea necesario
                if (filePath.EndsWith(".xml"))
                {
                    // Procesamiento de archivos XML
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(filePath); // Cargar el archivo XML en un objeto XmlDocument
                                           

                    // Guardar el objeto XmlDocument en el archivo
                    xmlDoc.Save(filePath); // Guardar el archivo XML con los cambios realizados
                }
                else if (filePath.EndsWith(".json"))
                {
                    // Procesamiento de archivos JSON
                    string fileContent = File.ReadAllText(filePath);
                    dynamic jsonContent = JsonConvert.DeserializeObject(fileContent); // Deserializar el JSON
                                                                                      

                    // Serializar el objeto JSON y guardarlo en el archivo
                    string jsonOutput = JsonConvert.SerializeObject(jsonContent); // Serializar el JSON
                    File.WriteAllText(filePath, jsonOutput); // Guardar el archivo JSON con los cambios realizados
                }
            }
        }
    }
}

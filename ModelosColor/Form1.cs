using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModelosColor
{
    public partial class Form1 : Form
    {
        private Bitmap originalImage;
        private PictureBox pictureBox;
        private ComboBox colorModelComboBox;

        public Form1()
        {
            InitializeComponent();
            InitializeCustomComponents();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void InitializeCustomComponents()
        {
            // Información del alumno
            Label studentInfoLabel = new Label
            {
                Text = "Alumnos: Julio Cesar Florentino Vigueras y Guadalupe Monserrath Martinez Barrera",
                Location = new Point(10, 10),
                AutoSize = true
            };
            this.Controls.Add(studentInfoLabel);

            // PictureBox
            pictureBox = new PictureBox
            {
                Location = new Point(10, 40),
                Size = new Size(760, 480),
                SizeMode = PictureBoxSizeMode.Zoom,
                BorderStyle = BorderStyle.FixedSingle
            };
            this.Controls.Add(pictureBox);

            // Load Button
            Button loadButton = new Button
            {
                Text = "Cargar Imagen",
                Location = new Point(10, 530)
            };
            loadButton.Click += LoadButton_Click;
            this.Controls.Add(loadButton);

            // ComboBox para seleccionar modelo de color
            colorModelComboBox = new ComboBox
            {
                Location = new Point(150, 530),  // Colócalo justo al lado del botón de cargar
                Width = 200
            };
            colorModelComboBox.Items.AddRange(new string[] { "Escala de Grises", "Sepia", "Negativo", "Rojo Dominante" });
            this.Controls.Add(colorModelComboBox);

            // Apply Button
            Button applyButton = new Button
            {
                Text = "Aplicar Transformación",
                Location = new Point(370, 530)
            };
            applyButton.Click += ApplyButton_Click;
            this.Controls.Add(applyButton);

            // Save Button
            Button saveButton = new Button
            {
                Text = "Guardar Imagen",
                Location = new Point(500, 530)
            };
            saveButton.Click += SaveButton_Click;
            this.Controls.Add(saveButton);
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Imágenes|*.bmp;*.jpg;*.jpeg;*.png";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    originalImage = new Bitmap(openFileDialog.FileName);
                    pictureBox.Image = originalImage;
                }
            }
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            if (originalImage != null)
            {
                ImageProcessor processor = new ImageProcessor(originalImage);

                // Verifica si hay un elemento seleccionado en el ComboBox
                if (colorModelComboBox.SelectedItem != null)
                {
                    string selectedModel = colorModelComboBox.SelectedItem.ToString();
                    Bitmap processedImage = null;

                    switch (selectedModel)
                    {
                        case "Escala de Grises":
                            processedImage = processor.ConvertToGrayscale();
                            break;
                        case "Sepia":
                            processedImage = processor.ConvertToSepia();
                            break;
                        case "Negativo":
                            processedImage = processor.ConvertToNegative();
                            break;
                        case "Rojo Dominante":
                            processedImage = processor.ConvertToRedDominant();
                            break;
                    }

                    if (processedImage != null)
                    {
                        pictureBox.Image = processedImage;
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione un modelo de color.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, cargue una imagen primero.");
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (pictureBox.Image != null)
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Imagen PNG|*.png|Imagen JPEG|*.jpg|Imagen BMP|*.bmp";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        pictureBox.Image.Save(saveFileDialog.FileName);
                    }
                }
            }
            else
            {
                MessageBox.Show("No hay imagen para guardar.");
            }
        }
    }
}



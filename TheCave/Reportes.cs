using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TheCave
{
    public partial class Reportes : Form
    {
        private int total;

        public Reportes()
        {
            InitializeComponent();
        }
        private void buttonRFN2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string pathName = Path.Combine(dlg.SelectedPath, DateTime.Now.ToString("yyyy-dd-M") + " Productos.pdf");
                total = 0;
                BLLProducto producto = new BLLProducto();
                DataTable dt = new DataTable();
                dt = producto.GetProdutosAll();

                var document = Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Margin(30);                    
                        page.Header().ShowOnce().Row(row =>
                        {
                            byte[] imageData = System.IO.File.ReadAllBytes("Logo.PNG");
                            row.ConstantItem(140).Image(imageData);
                            row.RelativeItem().Column(col2 =>
                            {
                                col2.Item().AlignCenter().Text(" ").Bold().FontSize(14);

                            });

                            row.RelativeItem().Border(1).Column(col =>
                            {
                                col.Item().Border(1).BorderColor("#257272").Background("#257272").AlignCenter().Text("Codigo Reporte").Bold().FontSize(14).FontColor("#fff");
                                col.Item().AlignCenter().Text(RandomString(8)).Bold().FontSize(10);
                            });
                        });

                        page.Content().PaddingVertical(10).Column(col1 =>
                        {
                            col1.Item().LineHorizontal(0.5f);
                            col1.Item().Text(" ").Bold().FontSize(10);
                            col1.Item().Text("Stock productos").Bold().FontSize(30);
                            col1.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn(3);
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                });

                                table.Header(header =>
                                {
                                    header.Cell().Background("#257272").Padding(2).Text("Producto").FontColor("#fff");
                                    header.Cell().Background("#257272").Padding(2).Text("Stock").FontColor("#fff");
                                    header.Cell().Background("#257272").Padding(2).Text("Precio").FontColor("#fff");
                                });

                                foreach (DataRow row in dt.Rows)
                                {
                                    table.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9").Padding(2).Text(row["Nombre"].ToString()).FontSize(10);
                                    table.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9").Padding(2).Text(row["Stock"].ToString()).FontSize(10);
                                    table.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9").Padding(2).Text("$"+row["Precio"].ToString()).FontSize(10);
                                }

                                col1.Item().LineHorizontal(0.5f);
                                col1.Item().Text(" ").Bold().FontSize(10);
                                col1.Item().Text("Productos a reponer").Bold().FontSize(30);
                                col1.Item().Table(table1 =>
                                {
                                    table1.ColumnsDefinition(columns =>
                                    {
                                        columns.RelativeColumn(3);
                                        columns.RelativeColumn();
                                    });

                                    table1.Header(header =>
                                    {
                                        header.Cell().Background("#257272").Padding(2).Text("Producto").FontColor("#fff");
                                        header.Cell().Background("#257272").Padding(2).Text("Precio").FontColor("#fff");
                                    });

                                    foreach (DataRow row in dt.Rows)
                                    {
                                        if (row["Stock"].ToString() == "0")
                                        {
                                            table1.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9").Padding(2).Text(row["Nombre"].ToString()).FontSize(10);
                                            table1.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9").Padding(2).Text("$"+row["Precio"].ToString()).FontSize(10);
                                            total += int.Parse(row["Precio"].ToString());
                                        }
                                    }

                                    col1.Item().AlignRight().Text("Total: $" + total).FontSize(12);
                                });
                            });
                        });

                        page.Footer().AlignRight().Text(txt =>
                        {
                            txt.Span("Pagina ").FontSize(10);
                            txt.CurrentPageNumber().FontSize(10);
                            txt.Span(" de ").FontSize(10);
                            txt.TotalPages().FontSize(10);
                        });
                    });
                });

                document.GeneratePdf(pathName);
            }
        }

        private void ButtonRFN1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string pathName = Path.Combine(dlg.SelectedPath, DateTime.Now.ToString("yyyy-dd-M") + " Alquileres.pdf");
                total = 0;
                BLLAlquiler alquiler = new BLLAlquiler();
                DataTable dt = new DataTable();
                dt = alquiler.getAlquileres();

                var document = Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Margin(30);
                        page.Header().ShowOnce().Row(row =>
                        {
                            byte[] imageData = System.IO.File.ReadAllBytes("Logo.PNG");
                            row.ConstantItem(140).Image(imageData);
                            row.RelativeItem().Column(col2 =>
                            {
                                col2.Item().AlignCenter().Text(" ").Bold().FontSize(14);
                            });

                            row.RelativeItem().Border(1).Column(col =>
                            {
                                col.Item().Border(1).BorderColor("#257272").Background("#257272").AlignCenter().Text("Codigo Reporte").Bold().FontSize(14).FontColor("#fff");
                                col.Item().AlignCenter().Text(RandomString(8)).Bold().FontSize(10);
                            });
                        });

                        page.Content().PaddingVertical(10).Column(col1 =>
                        {
                            col1.Item().LineHorizontal(0.5f);
                            col1.Item().Text(" ").Bold().FontSize(10);
                            col1.Item().Text("Alquileres").Bold().FontSize(30);
                            col1.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn(3);
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                });

                                table.Header(header =>
                                {
                                    header.Cell().Background("#257272").Padding(2).Text("Codigo").FontColor("#fff");
                                    header.Cell().Background("#257272").Padding(2).Text("Estacion").FontColor("#fff");
                                    header.Cell().Background("#257272").Padding(2).Text("Tiempo").FontColor("#fff");
                                    header.Cell().Background("#257272").Padding(2).Text("Precio").FontColor("#fff");
                                });

                                foreach (DataRow row in dt.Rows)
                                {
                                    table.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9").Padding(2).Text(row["CodAlquiler"].ToString()).FontSize(10);
                                    table.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9").Padding(2).Text(row["Estacion"].ToString()).FontSize(10);
                                    table.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9").Padding(2).Text(row["Tiempo"].ToString()).FontSize(10);
                                    table.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9").Padding(2).Text("$" + row["Precio"].ToString()).FontSize(10);
                                    total += int.Parse(row["Precio"].ToString());
                                }

                                col1.Item().AlignRight().Text("Total: $" + total).FontSize(12);
                            });
                        });

                        page.Footer().AlignRight().Text(txt =>
                        {
                            txt.Span("Pagina ").FontSize(10);
                            txt.CurrentPageNumber().FontSize(10);
                            txt.Span(" de ").FontSize(10);
                            txt.TotalPages().FontSize(10);
                        });
                    });
                });
                document.GeneratePdf(pathName);
            }
        }

       
        private Random random = new Random();
        public string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}



using System;
using System.Web.UI;

namespace AspNetWebApplication
{
    public partial class TablaMultiplicar : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;

            this.tabNumber.Items.Clear();
            for (int i = 1; i < 10; i++)
            {
                this.tabNumber.Items.Add(i.ToString());
            }

            this.tabNumber.ClearSelection();
            this.tabNumber.SelectedValue = "5";
        }

        protected void submitTabla_Click(object sender, EventArgs e)
        {
            var i = int.Parse(this.tabNumber.SelectedValue);
            var htmlTable = "";
            //Mostrar la tabla del número que recibe del formulario
            htmlTable += "<table class='table table-hover table-primary' style='width:332px'>";
            htmlTable += $"<thead><tr><th colspan='5'>Tabla del {i}</th></tr><thead>";

            //Ciclo del 1 al 10 para mostrar la tabla
            for (int a = 1; a <= 10; a++)
            {
                htmlTable += "<tr>";
                htmlTable +=  $"<td>{i}</td> <td>x</td> <td>{a}</td> <td>=</td> <th>{i*a}</th>";
                htmlTable += "</tr>";
            }
            htmlTable += "</table>";

            this.tablaResultado.InnerHtml = htmlTable;
        }
    }
}
using Amazon;
using Amazon.Rekognition;
using Amazon.Rekognition.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebFormApp
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
 
              ddlCiudad.Items.Add(new ListItem("Seleccione uno", "00"));
              ddlCiudad.Items.Add(new ListItem("Carro", "01"));
              ddlCiudad.Items.Add(new ListItem("Jeepeta", "02"));
            }
           


        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Application.Lock();
            Application["EDADGENERAL"] = 50;
            Application.UnLock();

            if (int.Parse(txtEdad.Text) > 17)
                Response.Redirect("paginasession.aspx?Codigo=" + txtEdad.Text);
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnVer_Click(object sender, EventArgs e)
        {
            Response.Write(ddlCiudad.SelectedValue);
            Response.Write(txtEdad.Text);
            Session["EDAD"] = txtEdad.Text;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (fuArchivo.HasFile)
            {
                //Crear cliente con la llave

                AmazonRekognitionClient rekognitionClient = new AmazonRekognitionClient("AKIAIE5LZMZN4CR6IO5Q", "xUtzMH5IxZmuZYrc9KSN83JE+pgf5J60+FajM65J", RegionEndpoint.USEast1);

                //Cargar la imagen

                Amazon.Rekognition.Model.Image image = new Amazon.Rekognition.Model.Image();

                image.Bytes = new System.IO.MemoryStream(fuArchivo.FileBytes);

                ////Moderacion

                //DetectModerationLabelsRequest detectModerationLabelsRequest = new DetectModerationLabelsRequest()

                //{
                //    Image = image,
                //    MinConfidence = 60
                //};

                //DetectModerationLabelsResponse detectModerationLabelsResponse = rekognitionClient.DetectModerationLabels(detectModerationLabelsRequest);

                //foreach (var item in detectModerationLabelsResponse.ModerationLabels)
                //{
                //    TextBox3.Text = TextBox3.Text + item.Name + "-" + item.Confidence.ToString() + "\r\n";
                //}

                //detectModerationLabelsResponse.ModerationLabels.Count

                ////Celebridades

                //RecognizeCelebritiesRequest recognizeCelebritiesRequest = new RecognizeCelebritiesRequest()

                //{

                //    Image = image

                //};

                // RecognizeCelebritiesResponse recognizeCelebritiesResponse = rekognitionClient.RecognizeCelebrities(recognizeCelebritiesRequest);

                // foreach (var item in recognizeCelebritiesResponse.CelebrityFaces)

                // {

                //     txtDetalle.Text = txtDetalle.Text + item.Name + ",";

                // }

                //Aplicar IA a imagen

                DetectLabelsRequest detectlabelsRequest = new DetectLabelsRequest()
                {
                    Image = image,

                    MaxLabels = 10,

                    MinConfidence = 77F
                };

                DetectLabelsResponse detectLabelsResponse = rekognitionClient.DetectLabels(detectlabelsRequest);

                foreach (var item in detectLabelsResponse.Labels)
                {
                    TextBox3.Text = TextBox3.Text + item.Name + "-" + item.Confidence.ToString() + "\r\n";
                }

                fuArchivo.SaveAs(MapPath("imagenes" + "\\" + fuArchivo.FileName));
                ingFoto.ImageUrl = "/Imagenes/" + fuArchivo.FileName;
            }
            if (fuArchivo.HasFile)
            {
                foreach (var item in fuArchivo.PostedFiles)
                {
                    item.SaveAs(MapPath("imagenes" + "\\" + item.FileName));
                }
            }
        }
    }
}
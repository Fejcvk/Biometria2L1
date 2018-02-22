using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace hrbmLab1
{
    public partial class Form1 : Form
    {
        List<ImgEntity> imgEntities;
        public Form1()
        {
            InitializeComponent();
        }
        private void directoryCrawler(string directoryPath)
        {
            try
            {
                imgEntities = new List<ImgEntity>();
                foreach(string fileName in Directory.GetFiles(directoryPath))
                {
                    ImgEntity entity = new ImgEntity();
                    imgEntities.Add(entity);
                    Console.WriteLine(fileName);
                }
                foreach(string seasonDirectory in Directory.GetDirectories(directoryPath))
                {
                    this.directoryCrawler(seasonDirectory);
                }
            }
            catch
            {
                MessageBox.Show("XDD","XDD");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = @"C:\Users\fejcakt\Downloads\UBIRIS_200_150_R";
            this.directoryCrawler(path);
        }
    }


    public class ImgEntity
    {
        private int id;
        private int personId;
        private string fileName;
        private Bitmap image;
        //ficzer incoming
        ImgEntity(int id, int personId, string fileName)
        {
            this.id = id;
            this.personId = personId;
            this.fileName = fileName;
        }
    }
}

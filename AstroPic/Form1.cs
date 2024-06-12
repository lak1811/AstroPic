using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NasaApodProject;


namespace NasaApodProject;

public partial class Form1 : Form
    
{
    private string url;
    public Form1()
    {
        InitializeComponent();
        this.Text = "Welcome to AstroPic!";
        StartPosition = FormStartPosition.Manual;
        Location = new Point(250, 100);

    }
    private void SetURL(string newURL)
    {
        url = newURL;
    }

    // Function to get the URL
    private string GetURL()
    {   
        return url;
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        
        
    }


    private async void button1_Click(object sender, EventArgs e)
    {
        
        button1.Enabled = false;
        button1.Text = "Wait";
        button1.BackColor = Color.Red;
        List<string> presentList = await ListExtraction.FetchAndProcessData();
        //Order of the values in the list::::

            //Copyright
            //Date
            //Title
            //Descr
            //HDURL
            //Type
            //Version
            //RegularURL

        


        
        if (presentList.Count > 0)
        {
            richTextBox1.Clear();//Descr
            richTextBox2.Clear(); //Title
            textBox1.Clear(); //Date
            textBox4.Clear();// Copyright
            textBox5.Clear(); //Sercive
            textBox6.Clear(); // URL
            textBox8.Clear(); //Mediatype
            pictureBox1.Load (presentList[4]);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            textBox4.Text = presentList[0];
            textBox1.Text = presentList[1];
            richTextBox2.Text = presentList[2];
            richTextBox1.Text = presentList[3];
            textBox6.Text = presentList[4];
            textBox8.Text = presentList[5];
            textBox5.Text = presentList[6];
            SetURL(presentList[4]);
            button1.Enabled = true;
            button1.Text = "Run";
            button1.BackColor = Color.LightGreen;
        }

    }

    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void label2_Click(object sender, EventArgs e)
    {

    }

    private void textBox8_TextChanged(object sender, EventArgs e)
    {

    }

    private void richTextBox1_TextChanged(object sender, EventArgs e)
    {

    }

    private void label10_Click(object sender, EventArgs e)
    {

    }

    private void label11_Click(object sender, EventArgs e)
    {

    }

    private void label5_Click(object sender, EventArgs e)
    {

    }

    private void label9_Click(object sender, EventArgs e)
    {

    }

    private void richTextBox2_TextChanged(object sender, EventArgs e)
    {

    }

    private void label1_Click(object sender, EventArgs e)
    {

    }

    private void textBox6_TextChanged(object sender, EventArgs e)
    {
       
    }


    private void pictureBox1_Click(object sender, EventArgs e)
    {
        string currentURL = GetURL();
        Process.Start(currentURL);

    }

    private void label6_Click(object sender, EventArgs e)
    {

    }

    private void label4_Click(object sender, EventArgs e)
    {

    }
}

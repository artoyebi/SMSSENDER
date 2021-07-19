using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.TwiML;

namespace SMSSENDER
{
    public partial class smsSender : Form
    {
        public smsSender()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtMessage.Text = "";
            txtAccountSID.Text = "";
            txtSender.Text = "";
            txtMessage.Text = "";
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {

                string accountSid = txtAccountSID.Text;
                string authToken = txtAuthToken.Text;
                string messageBody = txtMessage.Text;
                string twilioPhoneNumber = txtSender.Text;
                string receiverPhoneNumber = txtReceiver.Text;

               
                TwilioClient.Init(accountSid, authToken);
                

                var message = MessageResource.Create(
                    body: messageBody,
                    from: new Twilio.Types.PhoneNumber(twilioPhoneNumber),
                    to: new Twilio.Types.PhoneNumber(receiverPhoneNumber),
                    provideFeedback: true
                );

                MessageBox.Show(message.Sid, "SMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "SMSSENDER Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            
            this.Close();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}

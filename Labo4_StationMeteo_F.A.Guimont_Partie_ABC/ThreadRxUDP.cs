﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Labo4_StationMeteo_F.A.Guimont
{
    public class ThreadRxUDP
    {
        public delegate void monProtoDelegate(List<byte> trame, string srxlp); //étape #1: définir prototype de fonction... paramètres d'entrée et de retour
        public monProtoDelegate objDelegate;  //étape #2: on se déclare un objet delegate. (i.e. un pointeur de fonction ayant ce prototype)

        const int PORT_RX = 2223;  //Port de réception UDP
        const int MAX_TRAME = 13; //Grosseur max du buffer de réception
        private byte[] m_trameRx = new byte[MAX_TRAME];  //buffer de Rx


        public IPAddress ipClient;  //à titre d'info pour savoir qui a émit la trame UDP
        public int portClient; //idem pour le port
        private UdpClient udpClient;

        Form m_ptrFrmPrinc;

        // Constructeur
        public ThreadRxUDP(Form frmPrincipal)
        {
            m_ptrFrmPrinc = frmPrincipal;
            udpClient = new UdpClient(PORT_RX);
        }

        // Méthode principale appelée par le Thread
        public void FaitTravail()
        {
            IPEndPoint IpDistant = new IPEndPoint(IPAddress.Any, 60240);
            List<byte> trameRx = new List<byte>();
            string source = "";

            //le thread tourne toujours dans cette boucle en attente d'une trame UDP

            while (true)
            {
                m_trameRx = udpClient.Receive(ref IpDistant);
                ipClient = ((IPEndPoint)IpDistant).Address;  //ip du client UDP qui a émit la trame
                portClient = ((IPEndPoint)IpDistant).Port;   //port du client UDP qui a émit la trame

                if (m_trameRx.Length > 0)   // verifie si on a recu minimum 1 données
                {
                    trameRx.Clear();    // efface la trame
                    for (int i = 0; i < m_trameRx.Length; i++)  // incrémente tout ce qu'on a reçu 
                        trameRx.Add(m_trameRx[i]);  // met dans une variable 

                    source = ipClient + ":" + portClient;   // si c'est un cleint UDP qui a envoyer la trame 

                    if (m_trameRx.Count() == MAX_TRAME) //verifie si la trame est bien envoyer 
                        m_ptrFrmPrinc.BeginInvoke(objDelegate, trameRx, source);    // va écrire dans les textBox 
                }

            }
        }

        /// <summary>
        /// ferme le UDP
        /// </summary>
        public void ArreteClientUDP()
        {
            udpClient.Close();  // ferme le UDP 
        }
    }
}

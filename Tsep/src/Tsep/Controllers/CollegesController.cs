﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tsep.Entities;
using Tsep.Models;

namespace Tsep.Controllers
{
    public class CollegesController:Controller
    {

        private CloudStorageAccount account;
        private CloudTableClient tableclient;
        private CloudTable table;
        private CloudTable cutofs;
        private StorageCredentials creds;
        private TableQuery<CutOffEntity> que;
        private TableQuery<GroupEntity> que2;
        private CloudTable groupdet;
        private TableOperation operation;
        IEnumerable<SelectListItem> selectlist;
       ~CollegesController()
        {

        }
        public CollegesController()
        {
            creds = new StorageCredentials("eamcetts2016", "j76JE1NR/K2BAy57zaR4nN6JLris6eJ2Ourjs8GOKqaTMvHkX6k5SYA2ld1jZ45kcj9nAzgU49fqvv6Wwmi3tg==");
            account = new CloudStorageAccount(creds,false);
            tableclient = account.CreateCloudTableClient();
            table = tableclient.GetTableReference("Colleges");
            groupdet = tableclient.GetTableReference("GroupDetails");
            cutofs = tableclient.GetTableReference("Cutoffs");
            selectlist = new List<SelectListItem>
            {
                new SelectListItem() { Text="AUROBINDO INSTITUTE OF ENGG AND TECHNOLOGY", Value="ABIE"},
                new SelectListItem() { Text="AUROBINDO COLL OF PHARM SCI", Value="ABND"},
                new SelectListItem() { Text="A C E ENGINEERING COLLEGE", Value="ACEG"},
                new SelectListItem() { Text="ADAMS ENGINEERING COLLEGE", Value="ADAM"},
                new SelectListItem() { Text="AARUSHI GROUP OF INSTITUTIONS", Value="AGIW"},
                new SelectListItem() { Text="ABHINAV HI-TECH COLLEGE OF ENGINEERING", Value="AHTC"},
                new SelectListItem() { Text="ANNAMACHARYA INST OF TECHNOLOGY AND SCI", Value="AITH"},
                new SelectListItem() { Text="AIZZA COLLEGE OF ENGG AND TECHNOLOGY", Value="AIZA"},
                new SelectListItem() { Text="ABDULKALAM INST OF TECHNOLOGY AND SCI", Value="AKIT"},
                new SelectListItem() { Text="AL HABEEB COLL OF ENGG AND TECH", Value="ALHB"},
                new SelectListItem() { Text="ANURAG COLLEGE OF ENGINEERING", Value="ANRH"},
                new SelectListItem() { Text="ANURAG ENGINEERING COLLGE", Value="ANRK"},
                new SelectListItem() { Text="ANURAG PHARMACY COLLEGE", Value="ANRP"},
                new SelectListItem() { Text="ANWAR-ULOOM COLLEGE  OF PHARMACY", Value="ANWP"},
                new SelectListItem() { Text="ARJUN COLLEGE OF TECHNOLOGY AND SCIENCE", Value="ARJN"},
                new SelectListItem() { Text="ARYA COLLEGE OF PHARMACY", Value="ARYA"},
                new SelectListItem() { Text="ASHOKA  INST OF ENGINEERING TECHNOLOGY", Value="ASOK"},
                new SelectListItem() { Text="AVANTHIS SCIENTIFIC TECH AND RESEARCH ACADEMY", Value="ASRA"},
                new SelectListItem() { Text="AURORAS DESIGN ACADEMY", Value="AUDC"},
                new SelectListItem() { Text="AURORAS DESIGN INSTITUTE", Value="AUDU"},
                new SelectListItem() { Text="AURORAS ENGINEERING COLLEGE", Value="AURB"},
                new SelectListItem() { Text="AURORA SCIENTIFIC AND TECH RESEARCH ACADEMY", Value="AURC"},
                new SelectListItem() { Text="AURORAS SCIENTIFIC AND TECHNOLOGICAL INSTITUTE", Value="AURG"},
                new SelectListItem() { Text="AURORA S RESEARCH AND TECHNOLOGICAL INSTITUTE", Value="AURH"},
                new SelectListItem() { Text="AURORA S TECHNOLOGICAL AND MANAGEMENT ACADEMY", Value="AURK"},
                new SelectListItem() { Text="AURORAS TECHNOLOGICAL AND  RESEARCH INSTITUTE", Value="AURP"},
                new SelectListItem() { Text="AVANTHI INST OF PHARMSCI", Value="AVHP"},
                new SelectListItem() { Text="AVANTHI INST OF ENGG AND TECHNOLOGY", Value="AVIH"},
                new SelectListItem() { Text="AVN INST OF ENGG TECHNOLOGY", Value="AVNI"},
                new SelectListItem() { Text="AYAAN COLL OF ENGINEERING AND TECHNOLOGY", Value="AYAN"},
                new SelectListItem() { Text="SRI BALAJI COLLEGE OF PHARMACY", Value="BCPT"},
                new SelectListItem() { Text="BHARAT INSTITUTE OF ENGG AND TECHNOLOGY", Value="BIET"},
                new SelectListItem() { Text="BALAJI INST OF PHARM SCI", Value="BIPS"},
                new SelectListItem() { Text="BHARAT INSTITUTE OF TECHNOLOGY", Value="BITL"},
                new SelectListItem() { Text="BALAJI INSTITUTE OF TECHNOLOGY AND SCI", Value="BITN"},
                new SelectListItem() { Text="BOJJAM NARASIMHULU PHARM COLL FOR WOMEN", Value="BNPW"},
                new SelectListItem() { Text="BOMMA INST OF TECHNOLOGY AND SCI", Value="BOMA"},
                new SelectListItem() { Text="ANU BOSE INSTT OF TECHNOLOGY", Value="BOSE"},
                new SelectListItem() { Text="BHASKAR PHARMACY COLLEGE", Value="BPCP"},
                new SelectListItem() { Text="BHOJREDDY ENGINEERING COLLEGE FOR WOMEN", Value="BREW"},
                new SelectListItem() { Text="BRILLIANT GRAMMER SCHOOL EDNL SOC GRP OF INSTNS", Value="BRIG"},
                new SelectListItem() { Text="BRILLIANT INSTT OF ENGG AND TECHNOLOGY", Value="BRIL"},
                new SelectListItem() { Text="BROWNS COLL OF PHARMACY", Value="BRWN"},
                new SelectListItem() { Text="BANDARI SRINIVAS INSTITUTE OF TECHNOLOGY", Value="BSGP"},
                new SelectListItem() { Text="BHASKAR ENGINEERING COLLEGE", Value="BSKR"},
                new SelectListItem() { Text="BHARAT INST OF TECHNOLOGY AND SCIENCE FOR WOMEN", Value="BTSW"},
                new SelectListItem() { Text="B V RAJU INSTITUTE OF TECHNOLOGY", Value="BVRI"},
                new SelectListItem() { Text="BVRIT COLLEGE OF ENGINEERING FOR WOMEN", Value="BVRW"},
                new SelectListItem() { Text="CARE COLL OF PHARMACY", Value="CARE"},
                new SelectListItem() { Text="COLLEGE OF AGRICULTURAL ENGG", Value="CASR"},
                new SelectListItem() { Text="CHILKUR BALAJI COLLEGE OF PHARMACY", Value="CBCP"},
                new SelectListItem() { Text="CHAITANYA BHARATHI INSTITUTE OF TECHNOLOGY", Value="CBIT"},
                new SelectListItem() { Text="CHILKUR BALAJI INST OF TECHNOLOGY", Value="CBTV"},
                new SelectListItem() { Text="CHAITANYA COLL OF PHARM EDN AND RESEARCH", Value="CCRP"},
                new SelectListItem() { Text="COLLEGE OF DAIRY TECHNOLOGY", Value="CDTK"},
                new SelectListItem() { Text="COLLEGE OF FOOD SCIENCE AND TECHNOLOGY", Value="CFSB"},
                new SelectListItem() { Text="COLLEGE OF FOOD SCIENCE AND TECHNOLOGY", Value="CFSP"},
                new SelectListItem() { Text="COLLEGE OF FOOD SCIENCE AND TECHNOLOGY", Value="CFSR"},
                new SelectListItem() { Text="SRI CHAITANYA COLLEGE OF ENGG AND TECH", Value="CHET"},
                new SelectListItem() { Text="SREE CHAITANYA COLLEGE OF ENGINEERING", Value="CHTN"},
                new SelectListItem() { Text="SREE CHAITANYA INST OF PHARM SCI", Value="CHTP"},
                new SelectListItem() { Text="SREE CHAITANYA INST OF TECHNOLOGY SCIENCES", Value="CHTS"},
                new SelectListItem() { Text="CHAITANYA INST OF TECH AND SCIENCE", Value="CITS"},
                new SelectListItem() { Text="CHRISTU JYOTHI INSTITUTE OF TECHNOLOGY AND SCI", Value="CJIT"},
                new SelectListItem() { Text="CMR TECHNICAL CAMPUS", Value="CMRG"},
                new SelectListItem() { Text="C M R COLLEGE OF ENGG AND TECHNOLOGY", Value="CMRK"},
                new SelectListItem() { Text="CMR INSTITUTE OF TECHNOLOGY", Value="CMRM"},
                new SelectListItem() { Text="CMR ENGG COLLEGE", Value="CMRN"},
                new SelectListItem() { Text="C M R COLL OF PHARMACY", Value="CMRP"},
                new SelectListItem() { Text="CVM COLLEGE OF PHARMACY", Value="CVMP"},
                new SelectListItem() { Text="CVR COLLEGE OF ENGINEERING", Value="CVRH"},
                new SelectListItem() { Text="ANURAG GRP OF INSTNS- CVSR COLL OF ENGG", Value="CVSR"},
                new SelectListItem() { Text="DARIPALLY ANANTHA RAMULU COLLOF ENGGAND TECH", Value="DARE"},
                new SelectListItem() { Text="DECCAN COLLEGE OF ENGINEERING AND TECHNOLOGY", Value="DCET"},
                new SelectListItem() { Text="DEEVANA COLLEGE OF PHARMACY", Value="DCPS"},
                new SelectListItem() { Text="DHRUVA  INSTITUTE OF ENGG AND TECHNOLOGY", Value="DHRU"},
                new SelectListItem() { Text="DHANVANTHARI INST OF PHARM SCI", Value="DIPS"},
                new SelectListItem() { Text="DHANVANTHARI COLLEGE OF PHARM SCI", Value="DNVP"},
                new SelectListItem() { Text="D R K COLLEGE OF ENGINEERING AND TECHNOLOGY", Value="DRKC"},
                new SelectListItem() { Text="D R K INSTITUTE OF SCI AND TECHNOLOGY", Value="DRKI"},
                new SelectListItem() { Text="DECCAN SCHOOL OF PHARMACY", Value="DSOP"},
                new SelectListItem() { Text="D V R COLLEGE OF ENGINEERING AND TECHNOLOGY", Value="DVRC"},
                new SelectListItem() { Text="ELLENKI COLLGE OF ENGG AND TECHNOLOGY", Value="ELEN"},
                new SelectListItem() { Text="ELLENKI INSTITUTE OF ENGG AND TECHNOLOGY", Value="ELET"},
                new SelectListItem() { Text="GLOBAL COLLEGE OF PHARMACY", Value="GBCP"},
                new SelectListItem() { Text="GURRAM BALANARSAIAH INST OF PHARMACY", Value="GBNP"},
                new SelectListItem() { Text="GOPAL REDDY COLLEGE OF ENGG AND TECHNOLOGY", Value="GCET"},
                new SelectListItem() { Text="GEETHANJALI COLL OF PHARM", Value="GCPK"},
                new SelectListItem() { Text="GEETANJALI COLLEGE OF ENGG AND TECHNOLOGY", Value="GCTC"},
                new SelectListItem() { Text="GLAND INST OF PHARACEUTICAL SCIENCES", Value="GLND"},
                new SelectListItem() { Text="GLOBAL INST OF ENGINEERING AND TECHNOLOGY", Value="GLOB"},
                new SelectListItem() { Text="GANGA PHARMACY COLLEGE", Value="GNGP"},
                new SelectListItem() { Text="GURUNANAK INST OF TECHNOLOGY", Value="GNIT"},
                new SelectListItem() { Text="GANAPATHI ENGINEERING COLLGE", Value="GNPT"},
                new SelectListItem() { Text="G NARAYNAMMA INSTITUTE OF TECHNOLOGY AND SCI", Value="GNTW"},
                new SelectListItem() { Text="G P R COLLEGE OF PHARMACY", Value="GPRP"},
                new SelectListItem() { Text="GOKARAJU RANGARAJU COLLEGE OF PHARMACY", Value="GRCP"},
                new SelectListItem() { Text="GOKARAJU RANGARAJU INSTITUTE OF ENGG AND TECH", Value="GRRR"},
                new SelectListItem() { Text="GNYANA SARASWATHI COLL OF ENGG AND TECH", Value="GSCE"},
                new SelectListItem() { Text="GANDHI ACADEMY OF TECHNOLOGICAL EDUCATION", Value="GTEN"},
                new SelectListItem() { Text="GURUNANAK INSTTECH CAMPUS", Value="GURU"},
                new SelectListItem() { Text="HASVITA INST OF MGMT AND TECHNOLOGY", Value="HIMT"},
                new SelectListItem() { Text="HYDERABAD INST OF TECHNOLOGY AND MGMT", Value="HITM"},
                new SelectListItem() { Text="HOLY MARY INST OF TECH AND SCI - BPHARM", Value="HMIP"},
                new SelectListItem() { Text="HOLY MARY INST OF TECHNOLOGY", Value="HMTK"},
                new SelectListItem() { Text="HOLY MARY INSTITUTE OF TECH SCIENCE", Value="HOLY"},
                new SelectListItem() { Text="HI-POINT COLL OF ENGG AND TECHNOLOGY", Value="HPTC"},
                new SelectListItem() { Text="INSTITUTE OF AERONAUTICAL ENGINEERING", Value="IARE"},
                new SelectListItem() { Text="INDUR INSTITUTE OF ENGINEERING AND TECHNOLOGY", Value="IITT"},
                new SelectListItem() { Text="SRI INDU INSTITUTE OF ENGINEERING AND TECHNOLOGY", Value="INDI"},
                new SelectListItem() { Text="SRI INDU COLLEGE OF ENGG AND TECHNOLOGY", Value="INDU"},
                new SelectListItem() { Text="ISL ENGINEERING COLLEGE", Value="ISLC"},
                new SelectListItem() { Text="JAYAMUKHI INSTITUTE OF TECHNOLOGY AND SCIS", Value="JAYA"},
                new SelectListItem() { Text="JOGINPALLY B R PHARMACY COLLEGE", Value="JBCP"},
                new SelectListItem() { Text="J B INSTITUTE OF ENGG AND TECHNOLOGY", Value="JBIT"},
                new SelectListItem() { Text="JAYAMUKHI COLLEGE OF PHARMACY", Value="JCPN"},
                new SelectListItem() { Text="JYOTHISHMATHI COLLEGE OF PHARMACY", Value="JCPT"},
                new SelectListItem() { Text="JAGRUTI INSTITUTE OF ENGG AND TECHNOLOGY", Value="JIET"},
                new SelectListItem() { Text="JAYAMUKHI INST OF PHARM SCI", Value="JIPS"},
                new SelectListItem() { Text="JJINSTITUTE OF INFORMATION TECHNOLOGY", Value="JJIT"},
                new SelectListItem() { Text="JYOTHISHMATHI INST OF PHARM SCI", Value="JMIP"},
                new SelectListItem() { Text="JYOTHISMATHI COLL OF ENGG AND TECHNOLOGY", Value="JMTH"},
                new SelectListItem() { Text="JYOTHISHMATHI INST OF TECHNOLOGY SCIENCES", Value="JMTK"},
                new SelectListItem() { Text="JYOTHISHMATHI INSTITUTE OF TECHNOLOGY AND SCI", Value="JMTS"},
                new SelectListItem() { Text="JNTU COLLEGE OF ENGINEERING  KARIMNAGAR", Value="JNKR"},
                new SelectListItem() { Text="JNTU SCHOOL OF PLANNING AND ARCH - SELF FINANCE", Value="JNPASF"},
                new SelectListItem() { Text="JNTU COLLEGE OF ENGG  HYDERABAD", Value="JNTH"},
                new SelectListItem() { Text="JNTUH-5 YEAR INTEGRATED MBA  SELF FINANCE", Value="JNTHMB"},
                new SelectListItem() { Text="JNTUH-5 YEAR INTEGRATED MTECH  SELF FINANCE", Value="JNTHMT"},
                new SelectListItem() { Text="JNTU COLLEGE OF ENGG  MANTHANI", Value="JNTM"},
                new SelectListItem() { Text="J N T U COLLEGE OF ENGINEERING  SULTANPUR", Value="JNTS"},
                new SelectListItem() { Text="JOGINPALLY B R ENGINEERING COLLEGE", Value="JOGI"},
                new SelectListItem() { Text="JAYA PRAKASH NARAYAN COLLEGE OF ENGINEERING", Value="JPNE"},
                new SelectListItem() { Text="KSHATRIYA COLLEGE OF ENGINEERING", Value="KCEA"},
                new SelectListItem() { Text="KODADA INST OF TECHNOLOGY AND SCIENCE FOR WOMEN", Value="KDDW"},
                new SelectListItem() { Text="KGREDDY COLLEGE OF ENGG AND TECHNOLOGY", Value="KGRH"},
                new SelectListItem() { Text="KHAMMAM COLLEGE OF PHARMACY", Value="KHMP"},
                new SelectListItem() { Text="KRISHNAMURTHY INST OF TECHNOLOGY AND ENGG", Value="KITE"},
                new SelectListItem() { Text="KAKATIYA INSTITUTE OF TECHNOLOGY AND SCI", Value="KITS"},
                new SelectListItem() { Text="KAKATIYA INST OF TECHNOLOGY SCI FOR WOMEN", Value="KITW"},
                new SelectListItem() { Text="KLRCOLLEGE OF ENGG AND TECHNOLOGY PALONCHA", Value="KLRT"},
                new SelectListItem() { Text="KESHAV MEMORIAL INST OF TECHNOLOGY", Value="KMIT"},
                new SelectListItem() { Text="KHAMMAM INST OF TECHNOLOGY AND SCIENCE", Value="KMTS"},
                new SelectListItem() { Text="KASIREDDY NARAYANAREDDY COLL ENGG RES", Value="KNRR"},
                new SelectListItem() { Text="KOMMURI PRATAP REDDY INST OF TECHNOLOGY", Value="KPRT"},
                new SelectListItem() { Text="KL  R PHARMACY COLLEGE", Value="KRCP"},
                new SelectListItem() { Text="SRI KRUPA INSTITUTE OF PHARMACEUTICAL SCIS", Value="KRUP"},
                new SelectListItem() { Text="KAMALA INSTITUTE OF TECHNOLOGY AND SCIENCE", Value="KTKM"},
                new SelectListItem() { Text="K U COLLEGE OF ENGG  KOTHAGUDEM", Value="KUCE"},
                new SelectListItem() { Text="K U COLLEGE OF ENGG  KOTHAGUDEM", Value="KUCESF"},
                new SelectListItem() { Text="K U COLLEGE OF PHARMACEUTICAL SCIENCES", Value="KUCP"},
                new SelectListItem() { Text="UNIVERSITY COLLEGE OF ENGG AND TECH FOR WOMEN KU CAMPUS", Value="KUEWSF"},
                new SelectListItem() { Text="KU COLLEGE OF ENGINEERING  AND TECHNOLOGY", Value="KUWL"},
                new SelectListItem() { Text="LAQSHYA INST OF TECHNOLOGY AND SCIENCES", Value="LAQS"},
                new SelectListItem() { Text="LORDS INSTITUTE OF ENGINEERING AND TECHNOLOGY", Value="LRDS"},
                new SelectListItem() { Text="MAX INST OF PHARM SCI", Value="MAXP"},
                new SelectListItem() { Text="MADHIRA INSTITUTE OF TECHNOLOGY AND SCI", Value="MDRK"},
                new SelectListItem() { Text="MADIRA INST OF TECHNOLOGYAND SCI", Value="MDRP"},
                new SelectListItem() { Text="MATRUSRI ENGINEERING COLLEGE", Value="MECS"},
                new SelectListItem() { Text="MESCO COLLEGE OF PHARMACY", Value="MESP"},
                new SelectListItem() { Text="METHODIST COLLEGE OF ENGINEERING AND TECHNOLOGY", Value="METH"},
                new SelectListItem() { Text="MEGHA INST OF ENGG AND TECHNOLOGY FOR WOMEN", Value="MGHA"},
                new SelectListItem() { Text="MAHATMA GANDHI INSTITUTE OF TECHNOLOGY", Value="MGIT"},
                new SelectListItem() { Text="MGU COLLEGE OF ENGINEERING AND TECHNOLOGY", Value="MGUNSF"},
                new SelectListItem() { Text="MAHAVEER INSTITUTE OF SCI AND TECHNOLOGY", Value="MHVR"},
                new SelectListItem() { Text="MINA INST OF ENGG AND TECHNOLOGY FOR WOMEN", Value="MINA"},
                new SelectListItem() { Text="MEDHA INST OF SCI TECHNOLOGY FOR WOMEN", Value="MISW"},
                new SelectListItem() { Text="M J COLLEGE OF ENGINEERING AND TECHNOLOGY", Value="MJCT"},
                new SelectListItem() { Text="M L R INSTITUTE OF TECHNOLOGY", Value="MLID"},
                new SelectListItem() { Text="M L R INSTITUTE OF PHARMACY", Value="MLIP"},
                new SelectListItem() { Text="MALLA REDDY COLLEGE OF ENGG  TECHNOLOGY", Value="MLRD"},
                new SelectListItem() { Text="MARRI LAXMAN REDDY INST OF TECHNOLOGY AND MANAGEMENT", Value="MLRS"},
                new SelectListItem() { Text="MALLA REDDY INSTITUTE OF TECHNOLOGY", Value="MLTM"},
                new SelectListItem() { Text="M N R COLLEGE OF PHARMACY", Value="MNRP"},
                new SelectListItem() { Text="MOTHER TERESA INSTITUTE OF SCI AND TECHNOLOGY", Value="MOTK"},
                new SelectListItem() { Text="MALLA REDDY COLLEGE OF ENGINEERING", Value="MRCE"},
                new SelectListItem() { Text="MALLA REDDY COLLEGE OF PHARMACY", Value="MRCP"},
                new SelectListItem() { Text="MALLA REDDY ENGG COLLEGE FOR WOMEN", Value="MRCW"},
                new SelectListItem() { Text="MALLAREDDY ENGINEERING COLLEGE", Value="MREC"},
                new SelectListItem() { Text="MALLA REDDY ENGINEERING COLLEGE AND MANAGEMENT SCIENCES", Value="MREM"},
                new SelectListItem() { Text="MALLAREDDY INST OF ENGG AND TECHNOLOGY", Value="MRET"},
                new SelectListItem() { Text="MALLA REDDY COLLEGE OF ENGINEERING FOR WOMEN", Value="MREW"},
                new SelectListItem() { Text="MALLA REDDY INIST OF PHARM SCI", Value="MRIP"},
                new SelectListItem() { Text="MALLAREDDY INST OF TECHNOLOGY AND SCI", Value="MRIT"},
                new SelectListItem() { Text="MALLA REDDY PHARMACY COLLEGE", Value="MRPC"},
                new SelectListItem() { Text="ST MARTINS ENGINEERING COLLEGE", Value="MRTN"},
                new SelectListItem() { Text="MOTHER THERESA COLLEGE OF ENGG AND TECHNOLOGY", Value="MTEC"},
                new SelectListItem() { Text="MOTHER TERESA COLLEGE OF PHARMACY", Value="MTPG"},
                new SelectListItem() { Text="M V S R ENGINEERING COLLEGE", Value="MVSR"},
                new SelectListItem() { Text="NAGOLE INST OF TECHNOLOGY SCIENCE", Value="NAGL"},
                new SelectListItem() { Text="NAWAB SHAH ALAM KHAN COLL OF ENGG AND TECH", Value="NAWB"},
                new SelectListItem() { Text="NOVA COLLEGE OF PHARMEDNAND RESEARCH", Value="NBSP"},
                new SelectListItem() { Text="NALANDA COLLEGE OF PHARMACY", Value="NCOP"},
                new SelectListItem() { Text="NOBLE COLLEGE OF ENGG TECHNOLOGY FOR WOMEN", Value="NETW"},
                new SelectListItem() { Text="NIGAMA ENGINEERING COLLEGE", Value="NGMA"},
                new SelectListItem() { Text="NETAJI INSTITUTE OF ENGINEERING AND TECHNOLOGY", Value="NIET"},
                new SelectListItem() { Text="NALGONDA INST OF TECHNOLOGY AND SCIENCE", Value="NLGN"},
                new SelectListItem() { Text="NALLA NARASIMHA REDDY EDNL SOC GRP OF INSTNS", Value="NNRG"},
                new SelectListItem() { Text="NARSIMHAREDDY ENGINEERING COLLEGE", Value="NRCM"},
                new SelectListItem() { Text="NALLAMALLA REDDY ENGINEERING COLLEGE", Value="NREC"},
                new SelectListItem() { Text="NRI INST OF TECHNOLOGY", Value="NRIH"},
                new SelectListItem() { Text="NISHITHA COLLEGE OF ENGG AND TECHNOLOGY", Value="NSHT"},
                new SelectListItem() { Text="NETHAJI INSTT OF PHARM SCI", Value="NTJP"},
                new SelectListItem() { Text="OMEGA COLLEGE OF PHARMACY", Value="OMGP"},
                new SelectListItem() { Text="O U COLLEGE OF ENGG  HYDERABAD", Value="OUCE"},
                new SelectListItem() { Text="O U COLLEGE OF TECH  HYDERABAD", Value="OUCT"},
                new SelectListItem() { Text="PATHFINDER INST OF PHARM EDN AND RES", Value="PATH"},
                new SelectListItem() { Text="PRASAD ENGINEERING COLLEGE", Value="PECJ"},
                new SelectListItem() { Text="PRINCETON INST OF ENGG TECH FOR WOMEN", Value="PETW"},
                new SelectListItem() { Text="PRATHISHTA INST OF PHARM SCI", Value="PIPS"},
                new SelectListItem() { Text="PRIYADARSINI INST OF SCIENCE AND TECHNOLOGY", Value="PIST"},
                new SelectListItem() { Text="PALAMUR UNIVERSITY", Value="PLMU"},
                new SelectListItem() { Text="PRATAB NARENDAR REDDY COLL OF PHARMACY", Value="PNRP"},
                new SelectListItem() { Text="PROCADENCE INST OF PHARM SCI", Value="PPSG"},
                new SelectListItem() { Text="PRINCETON COLLEGE OF ENGG AND TECHNOLOGY", Value="PRIN"},
                new SelectListItem() { Text="PRIYADARSHINI COLL OF PHARMSCI", Value="PRIP"},
                new SelectListItem() { Text="PRRM ENGINEERING COLLEGE", Value="PRRM"},
                new SelectListItem() { Text="PULIPATI PRASAD COLL OF PHARM SCI", Value="PULI"},
                new SelectListItem() { Text="PULLA REDDY INST OF PHARMACY DINDIGUL", Value="PURD"},
                new SelectListItem() { Text="R B V R R WOMENS COLLEGE OF PHARMACY", Value="RBVW"},
                new SelectListItem() { Text="RAMANANDATIRTHA ENGINEERING COLL", Value="RECN"},
                new SelectListItem() { Text="R G R SIDDHANTHI COLLEGE", Value="RGRS"},
                new SelectListItem() { Text="RISHI MS INST OF ENGG AND TECH FOR WOMEN", Value="RITW"},
                new SelectListItem() { Text="RAJA MAHENDRA COLLEGE OF ENGINEERING", Value="RMCK"},
                new SelectListItem() { Text="RRSCOLLEGE OF ENGINEERING AND TECHNOLOGY", Value="RRST"},
                new SelectListItem() { Text="SAGAR GROUP OF INSTITUTIONS", Value="SAGR"},
                new SelectListItem() { Text="SRI SAI EDNL SOC GRP OF INSTNS", Value="SAIK"},
                new SelectListItem() { Text="SAI SPURTI INSTITUTE OF TECHNOLOGY", Value="SAIS"},
                new SelectListItem() { Text="SAHAJA INSTITUTE OF TECHNSCIENCES FOR WOMEN", Value="SAJW"},
                new SelectListItem() { Text="SANA  ENGINEERING COLLEGE", Value="SANA"},
                new SelectListItem() { Text="SWARNA BHARATHI COLLEGE OF ENGINEERING", Value="SBCE"},
                new SelectListItem() { Text="SUJALA BHARATHIS INST OF TECHNOLOGY", Value="SBIO"},
                new SelectListItem() { Text="SWARNA BHARATHI INSTITUTE OF SCI AND TECHNOLOGY", Value="SBIT"},
                new SelectListItem() { Text="SHADHAN COLL OF ENGINEERING AND TECHNOLOGY", Value="SCET"},
                new SelectListItem() { Text="SHADAN COLLEGE OF PHARMACY", Value="SCOP"},
                new SelectListItem() { Text="SCIENT INST OF PHARMACY", Value="SCTP"},
                new SelectListItem() { Text="SRI DATTA COLL OF ENGINEERING AND SCIENCE", Value="SDES"},
                new SelectListItem() { Text="SRIDEVI WOMENS ENGINEERING COLLEGE", Value="SDEW"},
                new SelectListItem() { Text="SREE DATTHA GRP OF INSTNS", Value="SDGI"},
                new SelectListItem() { Text="SRI DATTA COLLEGE OF PHARMACY", Value="SDIP"},
                new SelectListItem() { Text="SHAZ COLL OF ENGINEERING AND TECHNOLOGY", Value="SHAZ"},
                new SelectListItem() { Text="SAHASRA INST OF PHARM SCI", Value="SHIP"},
                new SelectListItem() { Text="SIDDHARTHA INSTT OF ENGG AND TECHNOLOGY", Value="SIEI"},
                new SelectListItem() { Text="SINDHURA COLLEGE OF ENGG AND TECHNOLOGY", Value="SIND"},
                new SelectListItem() { Text="SHSHRUT INSTITUTE OF PHARMACY", Value="SIOP"},
                new SelectListItem() { Text="SIDDHARTHA INSTITUTE OF PHARMACY", Value="SIPC"},
                new SelectListItem() { Text="SIDDHARTHA INSTT OF TECHNOLOGY AND SCIENCES", Value="SISG"},
                new SelectListItem() { Text="SARADA INSTITUTE OF TECHNOLOGY AND SCI", Value="SITK"},
                new SelectListItem() { Text="ST JOHN  COLLEGE OF PHARMACY", Value="SJPY"},
                new SelectListItem() { Text="SREE KAVITHA ENGINEERING COLLEGE", Value="SKEC"},
                new SelectListItem() { Text="SLCS INST OF ENGG AND TECHNOLOGY", Value="SLCH"},
                new SelectListItem() { Text="STMARYS COLLEGE OF PHARMACY", Value="SMPS"},
                new SelectListItem() { Text="SAMSKRUTHI COLLEGE OF ENGG AND TECHNOLOGY", Value="SMSK"},
                new SelectListItem() { Text="SRINIDHI INSTITUTE OF SCI AND TECHNOLOGY", Value="SNIS"},
                new SelectListItem() { Text="SCIENT INSTITUTE OF TECHNOLOGY", Value="SNTI"},
                new SelectListItem() { Text="S N VANITHA PHARMACY MAHA VIDYALAYA", Value="SNVM"},
                new SelectListItem() { Text="SARASWATHI COLLEGE OF PHARM SCI", Value="SPCS"},
                new SelectListItem() { Text="ST PETERS ENGINEERING COLLEGE", Value="SPEC"},
                new SelectListItem() { Text="SPOORTHY ENGINEERING COLLEGE", Value="SPHN"},
                new SelectListItem() { Text="SAMSKRUTHI COLLEGE OF PHARMACY", Value="SPKG"},
                new SelectListItem() { Text="STPAULS COLLEGE OF PHARMACY", Value="SPLP"},
                new SelectListItem() { Text="ST PETERS INSTITUTE OF PHARMACEUTICAL SCI", Value="SPOP"},
                new SelectListItem() { Text="S R R COLLEGE OF PHARMACEUTICAL SCIS", Value="SRCP"},
                new SelectListItem() { Text="SUDHEER REDDY COLLEGE OF ENGG AND TECH FOR WOMEN", Value="SRCW"},
                new SelectListItem() { Text="SREE COLLEGE OF PHARMACY", Value="SREE"},
                new SelectListItem() { Text="S R ENGINEERING COLLEGE", Value="SRHP"},
                new SelectListItem() { Text="S R INTERNATIONAL INST OF TECHNOLOGY", Value="SRHY"},
                new SelectListItem() { Text="SREE RAMA INST OF TECHNOLOGY AND SCI", Value="SRIT"},
                new SelectListItem() { Text="SUMATHI REDDY INST OF TECHNOLOGY FOR WOMEN", Value="SRIW"},
                new SelectListItem() { Text="S R THIRTHA INSTITUTE OF SCINCE AND TECHNOLOGY", Value="SRTI"},
                new SelectListItem() { Text="SWAMY RAMANANDA THIRTHA INST OF PHARM SCI", Value="SRTN"},
                new SelectListItem() { Text="SREYAS INST OF ENGG AND TECHNOLOGY", Value="SRYS"},
                new SelectListItem() { Text="S S J COLLEGE OF PHARMACY", Value="SSJP"},
                new SelectListItem() { Text="SSJ ENGINEERING COLLEGE", Value="SSJV"},
                new SelectListItem() { Text="SMT SAROJINI RAMULAMMA COLLEGE OF PHARMACY", Value="SSRP"},
                new SelectListItem() { Text="SR SARADA INST OF SCI AND TECHNOLOGY", Value="SSST"},
                new SelectListItem() { Text="STANLEY COLLEGE OF ENGG AND TECHNOLOGY FOR WOMEN", Value="STLW"},
                new SelectListItem() { Text="SULTAN UL-ULOOM COLLEGE OF PHARMACY", Value="SUUP"},
                new SelectListItem() { Text="S V COLLEGE OF ENGINEERING AND TECHNOLOGY", Value="SVEC"},
                new SelectListItem() { Text="SRI VENKATESWARA ENGINEERING COLLEGE", Value="SVES"},
                new SelectListItem() { Text="SATAVAHANA UNIVERSITY", Value="SVHU"},
                new SelectListItem() { Text="SATAVAHANA UNIVERSITY - SELF FINANCE", Value="SVHUSF"},
                new SelectListItem() { Text="SWAMI VIVEKANANDA INST OF PHARM SCI", Value="SVIP"},
                new SelectListItem() { Text="SWAMI VIVEKANANDA INST OF TECHNOLOGY", Value="SVIT"},
                new SelectListItem() { Text="SVS GRP OF INSTNS - SVS INST OF TECH", Value="SVSE"},
                new SelectListItem() { Text="SVS GRP OF INSTNS - SVS INST OF PHARMACY", Value="SVSP"},
                new SelectListItem() { Text="SHADHAN WOMENS COLL OF PHARM", Value="SWCP"},
                new SelectListItem() { Text="SHADHAN WOMENS COLL OF ENGG AND TECHNOLOGY", Value="SWET"},
                new SelectListItem() { Text="SWATHI INST OF TECHNOLOGY SCI", Value="SWIT"},
                new SelectListItem() { Text="TALLA PADMAVATHI COLLEGE OF PHARMACY", Value="TALP"},
                new SelectListItem() { Text="TRINITY COLLEGE OF ENGINEERING AND TECHNOLOGY", Value="TCEK"},
                new SelectListItem() { Text="TRINITY COLLEGE OF ENGINEERING AND TECHNOLOGY", Value="TCTK"},
                new SelectListItem() { Text="TIRUMALA INTEGRATED CAMPUS", Value="TITS"},
                new SelectListItem() { Text="TEEGALA KRISHNA REDDY ENGINEERING COLLEGE", Value="TKEM"},
                new SelectListItem() { Text="T K R COLLEGE OF ENGG AND TECHNOLOGY", Value="TKRC"},
                new SelectListItem() { Text="TEEGALA KRISHNA REDDY COLLEGE OF PHARMACY", Value="TKRP"},
                new SelectListItem() { Text="TIRUMALA COLL OF PHARMACY", Value="TMLP"},
                new SelectListItem() { Text="TUDI NARASIMHA REDDY INST OF TEC AND SCI", Value="TNRI"},
                new SelectListItem() { Text="TALLA PADMAVATHI COLL OF ENGINEERING", Value="TPCE"},
                new SelectListItem() { Text="TALLA PADMAVATHI PHARMACY COLLEGE", Value="TPCP"},
                new SelectListItem() { Text="TIRUMALA ENGINEERING COLLEGE", Value="TRML"},
                new SelectListItem() { Text="TRINITY COLLEGE OF PHARMACY", Value="TRNP"},
                new SelectListItem() { Text="TEEGALA RAMI REDDY COLL OF PHARMACY", Value="TRPM"},
                new SelectListItem() { Text="T R R COLLEGE OF ENGINEERING", Value="TRRC"},
                new SelectListItem() { Text="TRR COLLEGE OF PHARMACY", Value="TRRP"},
                new SelectListItem() { Text="TUDI RAMI REDDY INST OF TEC AND SCI", Value="TUDI"},
                new SelectListItem() { Text="UNITY COLLEGE OF PHARMACY", Value="UCPB"},
                new SelectListItem() { Text="VAAGDEVI COLLEGE OF ENGINEERING", Value="VAGE"},
                new SelectListItem() { Text="VAGDEVI COLLEGE OF PHARMACY", Value="VAGP"},
                new SelectListItem() { Text="VASAVI COLLEGE OF ENGINEERING", Value="VASV"},
                new SelectListItem() { Text="VIGNAN BHARATI INSTITUTE OF TECHNOLOGY", Value="VBIT"},
                new SelectListItem() { Text="VIDYA BHARATHI INSTITUTE OF TECHNOLOGY", Value="VBJN"},
                new SelectListItem() { Text="VISWESWARAYA COLL OF ENGG AND TECHNOLOGY", Value="VCET"},
                new SelectListItem() { Text="SRI VENKATESWARA COLLEGE OF PHARMACY", Value="VCOP"},
                new SelectListItem() { Text="VIJAY COLL OF PHARMACY", Value="VCPN"},
                new SelectListItem() { Text="VIVEKANANDA GRP OF INSTNS", Value="VGIH"},
                new SelectListItem() { Text="VIGNAN INST OF PHARM SCI", Value="VGNP"},
                new SelectListItem() { Text="VIGNAN INSTITUTE OF TECHNOLOGY AND SCI", Value="VGNT"},
                new SelectListItem() { Text="VAGDEVI PHARMACY COLLEGE", Value="VGPC"},
                new SelectListItem() { Text="VAAGESHWARI COLL OF ENGINEERING", Value="VGSE"},
                new SelectListItem() { Text="VAAGESWARI COLLEGE OF PHARMACY", Value="VGSP"},
                new SelectListItem() { Text="VAGDEVI ENGINEERING COLLEGE", Value="VGWL"},
                new SelectListItem() { Text="VIVEKANANDAS INST OF ENGG AND TECHNOLOGY", Value="VIEB"},
                new SelectListItem() { Text="SREE VAANMAYI INST OF ENGG AND TECH", Value="VIET"},
                new SelectListItem() { Text="VENKATESWARA INST OF PHARM SCI", Value="VIPN"},
                new SelectListItem() { Text="VAAGESWARI INST OF PHARMACY", Value="VIPS"},
                new SelectListItem() { Text="VATHSALYA INSTITUTE OF SCI AND TECHNOLOGY", Value="VISA"},
                new SelectListItem() { Text="VIGNANS INST OF TECHNOLOGY AND AERONAUTICAL ENGG", Value="VITA"},
                new SelectListItem() { Text="VINUTHNA INST OF TECHNOLOGY SCIENCE", Value="VITH"},
                new SelectListItem() { Text="SRI VISHWESWARAYA INST OF TECHNOLOGY AND SCI", Value="VITS"},
                new SelectListItem() { Text="V N R VIGNAN JYOTHI INSTITUTE OF ENGG AND TECH", Value="VJEC"},
                new SelectListItem() { Text="VIDYAJYOTHI INSTITUTE OF TECHNOLOGY", Value="VJIT"},
                new SelectListItem() { Text="VIJAYA ENGINEERING COLLEGE", Value="VJYA"},
                new SelectListItem() { Text="VIJAYA COLLEGE OF PHARMACY", Value="VJYH"},
                new SelectListItem() { Text="VIKAS COLL OF PHARMACEUTICAL SCIENCES", Value="VKSP"},
                new SelectListItem() { Text="VIJAYA KRISHNA INST OF TECHNOLOGY AND SCI", Value="VKTS"},
                new SelectListItem() { Text="VARDHAMAN COLLEGE OF ENGINEERING", Value="VMEG"},
                new SelectListItem() { Text="VIGNANS INST OF MANAGEMENT AND TECH FOR WOMEN", Value="VMTW"},
                new SelectListItem() { Text="VISION COLLEGE OF PHARMSCI AND RES", Value="VPRG"},
                new SelectListItem() { Text="VAAGDEVI INST OF PHARM SCI", Value="VPWL"},
                new SelectListItem() { Text="VIJAYA RURAL ENGINEERING COLLEGE", Value="VREC"},
                new SelectListItem() { Text="DR VRK WOMENS COLL OF ENGG AND TECHNOLOGY", Value="VRKW"},
                new SelectListItem() { Text="VATSALYA COLL OF PHARMACY", Value="VSLP"},
                new SelectListItem() { Text="VISHNU INST OF PHARM EDN AND RESEARCH", Value="VSNU"},
                new SelectListItem() { Text="VIVEKANANDA INSTT OF TECH AND SCI  BOMMAKAL", Value="VVKN"},
                new SelectListItem() { Text="WARANGAL INST OF TECHNOLOGY SCIENCE", Value="WITS"},
            };
            //query = new TableQuery<CollegeEntity>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "College"));
            //var result = table.ExecuteQuerySegmentedAsync(query, null);
            //colleges =  result.Result.ToList().Select(x => new SelectListItem
            //{
            //    Text = x.Name,
            //    Value = x.RowKey

            //});
        }
        public IActionResult Index()
        {
            var Model = new CollegeDetails();
            ViewBag.Page = "Colleges";
            Model.Colleges = selectlist;
            return View(Model);
        }
        [HttpPost]
        public IActionResult College(CollegeDetails colgdet)
        {
            colgdet.Colleges = selectlist;
            operation = TableOperation.Retrieve<CollegeEntity>("College", colgdet.college.RowKey);
            ViewBag.Page = "Colleges";
            var result = table.ExecuteAsync(operation);
            colgdet.college = (CollegeEntity)result.Result.Result;
            colgdet.colgselected = true;
            que = new TableQuery<CutOffEntity>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, colgdet.college.RowKey));
            colgdet.Cutoofs = cutofs.ExecuteQuerySegmentedAsync<CutOffEntity>(que, null).Result.ToList();
            que2 = new TableQuery<GroupEntity>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, colgdet.college.RowKey));
            colgdet.GroupDetails = groupdet.ExecuteQuerySegmentedAsync<GroupEntity>(que2, null).Result.ToList();
            return View(colgdet);
        }
    }
}

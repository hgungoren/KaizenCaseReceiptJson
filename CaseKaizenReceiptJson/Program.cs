using Newtonsoft.Json;

namespace CaseKaizenReceiptJson
{
    class Program
    {
        static void Main(string[] args)
        {
            string json = @"[
               {
                  ""locale"":""tr"",
                  ""description"":""TEŞEKKÜRLER\nGUNEYDOĞU TEKS. GIDA INS SAN. LTD.STI.\nORNEKTEPE MAH.ETIBANK CAD.SARAY APT.\nN:43-1 BEYOĞLU/ISTANBUL\nGÜNEŞLİ V.D. 4350078928 V. NO.\nTARIH : 26.08.2020\nSAAT : 15:27\nFİŞ NO : 0082\n54491250\n2 ADx 2,75\nCC.COCA COLA CAM 200 08 *5,50\n2701084\n1,566 KGx 1,99\nMANAV DOMATES PETEME *3,32\n2701076\n0,358 KGx 4,99\nMANAV BIBER CARLISTO 08 *1,79\n4\nEKMEK CIFTLI 01 *1,25\nTOPKDV *0,80\nTOPLAM *11,86\nNAKİT *20,00\nKDV KDV TUTARI KDV'LI TOPLAM\n01 *0,01 *1,25\n08 *0,79 *10,61\nKASİYER : SUPERVISOR\n00 0001/020/000084/1//82/\nPARA USTÜ *8,14\nKASİYER: 1\n2 NO:1330 EKÜ NO:0001\nMF YAB 15017876\n"",
                  ""boundingPoly"":{
                     ""vertices"":[
                        {
                           ""x"":35,
                           ""y"":88
                        },
                        {
                           ""x"":576,
                           ""y"":88
                        },
                        {
                           ""x"":576,
                           ""y"":1077
                        },
                        {
                           ""x"":35,
                           ""y"":1077
                        }
                     ]
                  }
               }]";

            try
            {
                List<JsonResponse> responses = JsonConvert.DeserializeObject<List<JsonResponse>>(json);

                foreach (var response in responses)
                {
                    PrintReceipt(response.Description);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("JSON parse hatası: " + ex.Message);
            }
        }

        static void PrintReceipt(string description)
        {
            string[] lines = description.Split('\n');

            for (int i = 0; i < lines.Length; i++)
            {
                Console.WriteLine(i + 1 + " " + lines[i]);
            }
        }
    }

    class JsonResponse
    {
        public string Locale { get; set; }
        public string Description { get; set; }
        public BoundingPoly BoundingPoly { get; set; }
    }

    class BoundingPoly
    {
        public List<Vertex> Vertices { get; set; }
    }

    class Vertex
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
string archivoCadete = "cadetes.csv";
string archivoCadeteria = "cadeteria.csv";


        
        using (StreamReader sr = new StreamReader(archivoCadete))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                // Dividir la línea por comas
                string[] values = line.Split(',');
                
                // Procesar los valores
                foreach (string value in values)
                {
                    Console.Write(value + " ");
                }
                Console.WriteLine();
            }
        }
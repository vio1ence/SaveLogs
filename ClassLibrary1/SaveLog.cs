using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ClassLibrary1
{
   public class SaveLogs
    {
        public event Action<string> message;
        public string Path;
        public SaveLogs() { }

        public SaveLogs(string path)
        {
            Path = path;
        }


        public async void Add(string message)
        {
            if (Path != null)
            {
                using (FileStream file = new FileStream($@"{Path}\logs.txt", FileMode.Append))
                {
                    byte[] array = System.Text.Encoding.Default.GetBytes($"{message}\n");
                    await file.WriteAsync(array, 0, array.Length);
                }
                this.message?.Invoke("Сохранение прошло успешно");
            }
            else
            {
                using (FileStream file = new FileStream("log.txt", FileMode.Append))
                {
                    byte[] array = System.Text.Encoding.Default.GetBytes($"{message}\n");
                    await file.WriteAsync(array, 0, array.Length);
                }
                this.message?.Invoke("Лог сохранён по стандартному пути");
            }

        }
    }
}

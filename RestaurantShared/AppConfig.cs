using Microsoft.Extensions.Configuration;
using RestaurantShared.DTO.Configuration;
using RestaurantShared.DTO.SQLData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Xml.Schema;

namespace RestaurantShared
{
    public class AppConfig
    {
        private static readonly Lazy<AppConfig> configer = new(() => new AppConfig());
        public static AppConfig Instance => configer.Value;
        private AppConfig() { }

        public EmailConfig? emailconfig { get; private set; }
        public ClientConfig? clientconfig { get; private set; }
        public ServerConfig? serverconfig { get; private set; }
        public SQLconfig? sqlconfig { get; private set; }


        public void Load()
        {
            // Hàm này sẽ tự động lấy thư mục gốc của project nào ĐANG GỌI NÓ
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            var Config = builder.Build();
            emailconfig = Config.GetSection("EmailConfig").Get<EmailConfig>();
            clientconfig = Config.GetSection("ClientConfig").Get<ClientConfig>();
            serverconfig = Config.GetSection("ServerConfig").Get<ServerConfig>();
            sqlconfig = Config.GetSection("SQLconfig").Get<SQLconfig>();
        }
    }
}

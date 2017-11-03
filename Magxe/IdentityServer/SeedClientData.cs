using System;
using Magxe.Dao;
using Magxe.Utils;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Magxe.IdentityServer
{
    internal static class SeedData
    {
        public static void SeedClients(MigrationBuilder builder)
        {
            var clients = new[,]
            {
                {"Ghost Admin", "d72bd484-af5f-46c0-8b0a-a9bc4943f141"},
                {"Ghost Frontend", "7d6afc6e-ff56-402b-9889-7d5a9542d3ce"},
                {"Ghost Scheduler", "3a7ceafa-bd95-4c05-a4fe-b54f13675d17"},
                {"Ghost Backup", "43e16bee-a378-4c66-9092-03ed538085ca"}
            };
            var clientsO = new string[4,5];
            for (var i = 0; i < 4; i++)
            {
                clientsO[i, 0] = Guid.NewGuid().ToString("N");
                clientsO[i, 1] = clients[i, 0];
                clientsO[i, 2] = clients[i, 1];
                clientsO[i, 3] = Guid.NewGuid().ToString("N");
                clientsO[i, 4] = Slug.Slugify(clients[i, 0]);
            }
            builder.InsertData(
                "Clients",
                new[] {"Id", "Name", "Uuid", "Secret", "Slug"},
                clientsO
            );
        }
    }
}
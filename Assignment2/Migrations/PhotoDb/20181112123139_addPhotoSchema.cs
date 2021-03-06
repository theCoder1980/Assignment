﻿using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Assignment2.Migrations.PhotoDb
{
    public partial class addPhotoSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    albumId = table.Column<int>(maxLength: 100, nullable: false),
                    thumbnailUrl = table.Column<string>(maxLength: 100, nullable: false),
                    title = table.Column<string>(maxLength: 100, nullable: false),
                    url = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photos");
        }
    }
}

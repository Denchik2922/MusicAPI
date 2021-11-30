using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Configurations
{
	public class MusicianConfiguration : IEntityTypeConfiguration<Musician>
    {
        public void Configure(EntityTypeBuilder<Musician> builder)
        {
            builder.HasData(
            new Musician
            {
                Id = 1, FirstName = "Phils", LastName = "Rudd", Country = "Australia", GroupId = 1
            },
            new Musician
            {
                Id = 2, FirstName = "Clifford", LastName = "Williams", Country = "England", GroupId = 1
            },
            new Musician
            {
                Id = 3, FirstName = "Brian", LastName = "Francis", Country = "England", GroupId = 1
            },
            new Musician
            {
                Id = 4, FirstName = "Jimi", LastName = "Hendrix", Country = "England", GroupId = 1
            },
            new Musician
            {
                Id = 5, FirstName = "James", LastName = "Patrick", Country = "England", GroupId = 1
            },
            new Musician
            {
                Id = 6, FirstName = "Eric", LastName = "Clapton", Country = "England", GroupId = 1
            },
            new Musician
            {
                Id = 7, FirstName = "Bernard", LastName = "Rich", Country = "England", GroupId = 1
            },
             new Musician
             {
                 Id = 8, FirstName = "Jack", LastName = "DeJohnette", Country = "England", GroupId = 1
             }
            );

        }
	}
}

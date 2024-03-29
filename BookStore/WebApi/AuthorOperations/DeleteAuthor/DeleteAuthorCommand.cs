﻿using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.AuthorOperations.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        public int AuthorId { get; set; }
        private readonly IBookStoreDbContext _dbContext;
        public DeleteAuthorCommand(IBookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var author = _dbContext.Authors.SingleOrDefault(x => x.Id == AuthorId);

            if (author is null)
            {
                throw new InvalidOperationException("Yazar Bulunamadı.");
            }

            _dbContext.Authors.Remove(author);
            _dbContext.SaveChanges();
        }

    }
}

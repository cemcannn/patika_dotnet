using AutoMapper;
using System;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.AuthorOperations.UpdateAuthor
{
    public class UpdateAuthorCommand
    {
        public int AuthorId { get; set; }
        public UpdateAuthorModel Model { get; set; }
        private readonly IBookStoreDbContext _dbContext;

        public UpdateAuthorCommand(IBookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var author = _dbContext.Authors.SingleOrDefault(x => x.Id == AuthorId);

            if (author is null)
            {
                throw new InvalidOperationException("Yazar Bulunamadı!");
            }

            author.Name = Model.Name == default ? author.Name : Model.Name;
            author.Lastname = Model.Lastname == default ? author.Lastname : Model.Lastname;
            author.BirthDate = Model.BirthDate == default ? author.BirthDate : Model.BirthDate;
            _dbContext.SaveChanges();
        }
    }
    public class UpdateAuthorModel
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public DateTime BirthDate { get; set; }
    }
}

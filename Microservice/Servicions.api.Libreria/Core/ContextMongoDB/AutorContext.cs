using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Servicions.api.Libreria.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicions.api.Libreria.Core.ContextMongoDB
{
    public class AutorContext : IAutorContext
    {
        private readonly IMongoDatabase _db;

        public AutorContext(IOptions<MongoSettings> options) {
            var client = new MongoClient(options.Value.ConnectionString);
            _db = client.GetDatabase(options.Value.Database);
        }

        IMongoCollection<Autor> IAutorContext.Autores => _db.GetCollection<Autor>("autor");
    }
}

﻿using System.Collections.Generic;
using System.Linq;
using Common;
using Common.data;
using log4net;
using LiteDB;

namespace ConferenceTracker.core {
    internal class SqliteStorage : IStorage {
        private static readonly ILog Log = LogManager.GetLogger(typeof(SqliteStorage));

        private readonly LiteCollection<Conference> _conferenceCollection;
        private readonly LiteDatabase _db;

        /// <summary>
        ///     Хранилице данных по конференциям на основе БД sqlite. Имя по умолчанию.
        /// </summary>
        public SqliteStorage() : this("conference.db") {
        }

        /// <summary>
        ///     Хранилице данных по конференциям на основе БД sqlite. Имя задается.
        /// </summary>
        public SqliteStorage(string dbPath) {
            Log.Debug("Init DB: " + dbPath);
            _db = new LiteDatabase(dbPath);
            _conferenceCollection = _db.GetCollection<Conference>("Conference");
        }

        public List<Conference> ListConferences() {
            return _conferenceCollection.FindAll().ToList();
        }

        public Conference GetConference(string section) {
            return _conferenceCollection.FindOne(d => d.Section.Equals(section));
        }

        public long Count => _conferenceCollection.Count();

        public void AddOrUpdate(Conference conference) {
            _conferenceCollection.Upsert(conference);
            _conferenceCollection.EnsureIndex(d => d.Section);
        }

        public void Close() {
            Log.Debug("Close DB");
            _db?.Dispose();
        }
    }
}
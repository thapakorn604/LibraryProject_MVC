using System;
using System.Collections.Generic;
using LibraryProject.Abstract;
using LibraryProject.Entities;

namespace LibraryProject.Models
{
    public class RecordRepository : IRecordRepository
    {
        private static RecordRepository recordRepo = new RecordRepository();

        static List<Record> recordList;
        static int counter;

        private RecordRepository()
        {
            recordList = new List<Record>();
            counter = 1;
        }

        public bool AddRecord(Record record)
        {
            throw new NotImplementedException();
        }

        public bool EditRecord(int recordId)
        {
            throw new NotImplementedException();
        }

        public int GetCounter()
        {
            throw new NotImplementedException();
        }

        public Record GetRecord(int recordId)
        {
            throw new NotImplementedException();
        }

        public List<Record> GetRecordList()
        {
            throw new NotImplementedException();
        }

        public void SetCounter(int value)
        {
            throw new NotImplementedException();
        }

        public static RecordRepository GetRecordRepository()
        {
            return recordRepo;
        }

        public bool RemoveRecord(int recordId)
        {
            throw new NotImplementedException();
        }
    }
}
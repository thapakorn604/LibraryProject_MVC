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
        private static int counter;

        private RecordRepository()
        {
            recordList = new List<Record>();
            counter = 1;
        }

        public bool AddRecord(Record record)
        {
            if (record != null){
                recordList.Add(record);
                return true;
            }else{
                return false;
            }
        }

        public bool EditRecord(Record record)
        {
            if (record != null)
            {
                int index = recordList.FindIndex(r => r.recordId == record.recordId);
                recordList[index] = record;
                return true;
            }else{
                return false;
            }
        }

        public int GetCounter()
        {
            return counter;
        }

        public Record GetRecord(int recordId)
        {
            return recordList.Find(r => r.recordId == recordId);
        }

        public List<Record> GetRecordList()
        {
            return recordList;
        }

        public void SetCounter(int value)
        {
            counter = value;
        }

        public static RecordRepository GetRecordRepository()
        {
            return recordRepo;
        }

        public bool RemoveRecord(int recordId)
        {
            int index = recordList.FindIndex(r => r.recordId == recordId);

            if(index >=0 && index <= recordList.Count){
                recordList.RemoveAt(index);
                return true;
            }else{
                return false;
            }
        }
    }
}
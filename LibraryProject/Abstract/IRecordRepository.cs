using System;
using System.Collections.Generic;
using LibraryProject.Entities;

namespace LibraryProject.Abstract
{
    public interface IRecordRepository
    {
        bool AddRecord(Record record);
        bool EditRecord(Record record);
        Record GetRecord(int recordId);
        bool RemoveRecord(int recordId);
        List<Record> GetRecordList();
        int GetCounter();
        void SetCounter(int value);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

public class JsonReader
{
    //need to paramterize this one
    string jsonFilePath = "./DataDictionaries/ER.json";
    /**Method to read test data records for a particular test data id
    */

    public string GetTestDataValue(int testDataID,String dataRecord)

    {
        string json = File.ReadAllText(jsonFilePath);
        
        List <InputDataModel> inputDataModels=JsonConvert.DeserializeObject<List<InputDataModel>>(json);
        //var d = from data in inputDataModels where data.TestDataId == "1" select data;
        var data1=inputDataModels[testDataID-1].ExpectedPageTitle;
        return data1;
    }
}
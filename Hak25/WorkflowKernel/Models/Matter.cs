public class Matter
{
    public string MatterReferenceNo { get; set; }
    public int FileID { get; set; }
    public int BranchID { get; set; }
    public int AppID { get; set; }
    public string App_Code { get; set; }
    public string MatterDetails { get; set; }
    public int Closed { get; set; }
    public string RateCategory { get; set; }
    public string ClientName { get; set; }
    public string Company_Name { get; set; }
    public string FeeEarner { get; set; }
    public int MatterCounter { get; set; }
    public string EBilling { get; set; }
    public string UfnValue { get; set; }
    public bool IsPlotMatter { get; set; }
    public bool IsPlotMasterMatter { get; set; }
    public string Client_Ref { get; set; }
    public bool LegalLAACivilBilling { get; set; }
    public bool IsLegalAid { get; set; }
    public bool IsProspectMatter { get; set; }
    public bool IsCompleteMatter { get; set; }
    public bool IsFavorite { get; set; }
    public bool IsDestroyed { get; set; }
}

public class DataWrapper
{
    public List<Matter> Data { get; set; }
    public int Total { get; set; }
}

public class ApiResponse
{
    public DataWrapper Data { get; set; }
    public string Status { get; set; }
}

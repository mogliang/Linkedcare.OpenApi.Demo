using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linkedcare.OpenApi.Demo
{
    public interface IOpenApiProxy
    {
        OpenApiToken GetSaasToken();
        PageDto<OfficeDto> GetOffices(QueryInputBase input);
        PageDto<PatientDto> GetPatients(OfficeQueryInput input);
    }

    public class OpenApiToken
    {
        public string Error { set; get; }
        public string Token { set; get; }
        public DateTime ExpiredTime { set; get; }
    }

    public class QueryInputBase
    {
        public DateTime FromTime { set; get; }
        public int PageIndex { set; get; }
    }

    public class OfficeQueryInput : QueryInputBase
    {
        public string OfficeId { set; get; }
    }

    public class PageDto<T>
    {
        public int TotalCount { set; get; }
        public int PageIndex { set; get; }
        public int PageCount { set; get; }
        public List<T> Data { set; get; }
    }

    public class OfficeDto : DtoBase
    {
        public string Name { set; get; }
        public string Abbreviation { set; get; }
    }

    public class DtoBase
    {
        public string Id { set; get; }
        public Status Status { set; get; }
        public string Note { set; get; }
    }

    public enum Status
    {
        Disabled = 0,
        Enabled = 1,
    }
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linkedcare.OpenApi.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            // 获得配置
            var config = new OpenApiConfig
            {
                ApiAddress = ConfigurationManager.AppSettings["openApiAddress"],
                Secret = ConfigurationManager.AppSettings["openApiSecret"],
            };

            // 创建API代理
            var proxy = new OpenApiProxy(config);

            // 获得诊所列表
            var offices = proxy.GetOffices(new QueryInputBase { PageIndex = 1 });

            // 查询第一个诊所的患者
            var syncDate = new DateTime(2000, 1, 1);
            var officeId = offices.Data[0].Id;
            var patients = proxy.GetPatients(new OfficeQueryInput { FromTime = syncDate, PageIndex = 1, OfficeId = officeId });
        }
    }
}

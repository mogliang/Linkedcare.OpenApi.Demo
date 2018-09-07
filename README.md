# E看牙OpenApi接口Demo

### 运行方式
1. 用VisualStudio 打开项目
2. 打开配置文件 App.config , 填写OpenApi的服务地址和票据

```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <appSettings>
    <add key="openApiAddress" value="http://openapi.lctest.cn:6001/public/v1"/>
    <add key="openApiSecret" value="[请问领健索取票据]"/>
  </appSettings>
  <startup>
    <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.6.1" />
  </startup>
</configuration>
```

3. 运行项目

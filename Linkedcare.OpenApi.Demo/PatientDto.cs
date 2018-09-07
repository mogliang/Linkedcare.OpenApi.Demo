using System;

namespace Linkedcare.OpenApi.Demo
{
    public class PatientDto
    {
        public string OfficeId { set; get; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 首拼码
        /// </summary>
        public string NameCode { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 病历号
        /// </summary>
        public string PrivateId { get; set; }

        /// <summary>
        /// 其它病历号
        /// </summary>
        public string OtherPrivateId { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public SexType Sex { get; set; }

        /// <summary>
        /// 生日类型
        /// </summary>
        public BirthType? BrithType { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public DateTime? Birth { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 电话号码
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 职业
        /// </summary>
        public string Occupation { get; set; }

        /// <summary>
        /// 国籍
        /// </summary>
        public string Nationality { get; set; }

        /// <summary>
        /// 身份证
        /// </summary>
        public string IdentityCard { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string HomeAddress { get; set; }

        /// <summary>
        /// 患者类型
        /// </summary>
        public string PatientType { get; set; }

        /// <summary>
        /// 是否归档
        /// </summary>
        public bool IsArchived { get; set; }

        /// <summary>
        /// 标签
        /// </summary>
        public string Tag { get; set; }

        /// <summary>
        /// 一级来源
        /// </summary>
        public string SourceLevel1 { get; set; }

        /// <summary>
        /// 二级来源
        /// </summary>
        public string SourceLevel2 { get; set; }

        /// <summary>
        /// 三级来源
        /// </summary>
        public string SourceLevel3 { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Notes { get; set; }
    }

    /// <summary>
    /// 生日类型
    /// </summary>
    public enum BirthType
    {
        Common = 0,
        Traditional = 1,
    }

    /// <summary>
    /// 性别
    /// </summary>
    public enum SexType : byte
    {
        /// <summary>
        /// 未知
        /// </summary>
        Unknow,
        /// <summary>
        /// 男
        /// </summary>
        Male,
        /// <summary>
        /// 女
        /// </summary>
        Female
    }
}

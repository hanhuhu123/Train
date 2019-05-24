using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2
{
    public class BuyConfig
    {
        // 应用ID,您的APPID
        public static string app_id = "2016092900623907";

        // 支付宝网关
        public static string gatewayUrl = "https://openapi.alipaydev.com/gateway.do";

        // 商户私钥，您的原始格式RSA私钥
        public static string private_key = "MIIEowIBAAKCAQEAq8RCDceaAWHaMQb5pwPEeQ8TgnHCLDZE5DwZgak9lD8UCWJ4+ne4NeT6g62w2IUe8Z5OaWOcPLW1lIy++EY+nuKQKr3kyJOdtwx22f4vWJ1ttwpWhqvHJuhtOXAsWPhr5p9rFyRu5sOVexjI1vEBLAIP+j7JUo7xMPCKwGdBq7kR3BedKvVEmXYSMZujnsidzL74SpFKrA383D9ldXVSfph+HaqWmzwo+4Sca/i8+CvdFL+kMMaaN5Xf/jzzI6xEvJznFKYDExYtiFoWxIU7b0Yzvevni/A1xO0KYrhlerjG+tvKDpGx+BhrET86ys68c7xoLwsIiHzgwAPKIoNBYQIDAQABAoIBAHPvnRIF9roWHRrYdWu4jEWV2npCZGhJHQjcU+8Dl4/XX6PR9oxAgHLIIhr9Ao+ykqdNTemulUcY8v3YXhHf/+ZoUBy5XZHQqTRjUlljSvvKDsLsVGjDy0FEwmxxfU10KAha9AKD0eMqglu659zEgSD+J2CmPmbeGogI4+5oA5hu0BGVZsHYhe3QAG2/pkBN3T2IHgyc8J55o577SeoNfqQSvHam5v5OSgLM2+b6h8GpCxqNS2MfU5nZsQirAMRsMthxyDutWzKyqeBo63yEVK/pjjWUrrSSwx8rQPFryQNfVhgGVTak8T+ij0bxYJukMrdTZsaq34C6NvfpnofgQAECgYEA2TKzO38JV6dxdjBLwwoOliLsG78VcbVHDC5zRzIa7c2/0SBV5xz4fJjMd9wwo0TbeQ4HQXKOYgykzeVorJ9AMjzaCBcmKpyMapTPurDqDYXSNrm4rbXN1fr+l6PdhAX1xAmFuolaMIOtWdYMWt6Fv2LrK9YDXHwWEpwKrSeNugECgYEAynPOFwIvXyq15TK9nBg67rfKxfhjhDfyMw+krbXSrv2FEFxPNP+kmkJl7L0SAWGX1gJI701J1mQIC/1FHnSPN4FEn6JhlC86aK5X3cdF6g4EAnwOHcRHIAfjRzQ3d//fy3DQ1JgxQBEanPfC+vp3DZvE4RrwuvbtOOFXQJA5x2ECgYATtmJF+BWk+vF1RJTbssH4Jls/eWw80bMNC/oyb/25r37FQCYLv7ldtZB5IGbZqpowtnE6I2eAxpz+gt+pKxrsdFFlgpRYMbUcxzzDOONFLuwRQ3HbcjCoRwtsP9cO8GuJy0Nz1pt0476L9L1SUffZkuS9KcNMVYa7UaY2aOyYAQKBgQDB9EQi4uMDZ2Wv2PayTrxW6xmGpDqi9v5AUOJR0XmwUA1k6Sqw+aF2b9o5/cD8NcVDMBkzuXXdwSO8aL4JOV3jrSJTVTvqvXxVwYFIZZrjat4Ii1Tyy5Hga+4fzzS88BQ1UTWgFtZILJq0euD/lWjtTqhFiIvMcrg94BS5M/NGwQKBgBk8gGm3HjqdRxuz0at4ceBXzrS5hEyRlufrGNYdMAxul9mJtVrnRcTCxYulExsvnVPhRStSJuNK6UqxHMw+4AdzbD/fF/KDnl+N6d2k428Qf51VM4uPXQTobaw0GgEAp2ChydOoLTu33zlKxwk0C2icSAGY/25Q7+KdfOnKVfgy";

        // 支付宝公钥,查看地址：https://openhome.alipay.com/platform/keyManage.htm 对应APPID下的支付宝公钥。
        public static string alipay_public_key = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAq8RCDceaAWHaMQb5pwPEeQ8TgnHCLDZE5DwZgak9lD8UCWJ4+ne4NeT6g62w2IUe8Z5OaWOcPLW1lIy++EY+nuKQKr3kyJOdtwx22f4vWJ1ttwpWhqvHJuhtOXAsWPhr5p9rFyRu5sOVexjI1vEBLAIP+j7JUo7xMPCKwGdBq7kR3BedKvVEmXYSMZujnsidzL74SpFKrA383D9ldXVSfph+HaqWmzwo+4Sca/i8+CvdFL+kMMaaN5Xf/jzzI6xEvJznFKYDExYtiFoWxIU7b0Yzvevni/A1xO0KYrhlerjG+tvKDpGx+BhrET86ys68c7xoLwsIiHzgwAPKIoNBYQIDAQAB";

        // 签名方式
        public static string sign_type = "RSA2";

        // 编码格式
        public static string charset = "UTF-8";
    }
}
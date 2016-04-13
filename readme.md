## OpenMusic

A project is a simple music player, now it works on baidu music.  

## Baidu Rest

### Gedan

```XML
{
  "error_code": 22000,
  "total": 5796,
  "havemore": 1,
  "content": [
    {
      "listid": "6437",
      "listenum": "105127",
      "collectnum": "436",
      "title": "\u6211\u4eec\u76f8\u7231\u5427 \u5728\u82b1\u5f00\u7684\u5b63\u8282",
      "pic_300": "http:\/\/a.hiphotos.baidu.com\/ting\/pic\/item\/d6ca7bcb0a46f21f88e86ce8f1246b600d33aea8.jpg",
      "tag": "\u751c\u871c,\u60c5\u4fa3,\u6d6a\u6f2b,couple",
      "desc": "\u6211\u4eec\u76f8\u7231\u5427\uff0c\u65e0\u8bba\u5929\u7a7a\u662f\u4ec0\u4e48\u989c\u8272\uff0c\u65e0\u8bba\u96e8\u6ef4\u4f1a\u843d\u5728\u54ea\u91cc\uff0c\u65e0\u8bba\u4f60\u6211\u4ec0\u4e48\u65f6\u5019\u76f8\u9047\uff0c\u6211\u4eec\u76f8\u7231\u5427\u3002",
      "pic_w300": "http:\/\/a.hiphotos.baidu.com\/ting\/pic\/item\/d6ca7bcb0a46f21f8b1a63e8f1246b600c33ae5a.jpg",
      "width": "520",
      "height": "520"
    },
    {
      "listid": "6400",
      "listenum": "29722",
      "collectnum": "573",
      "title": "\u6211\u7684\u3010\u6447\u6eda\u4e50\u3011\u5f88\u3010\u82f1\u5f0f\u3011",
      "pic_300": "http:\/\/c.hiphotos.baidu.com\/ting\/pic\/item\/6a600c338744ebf847dab67fdef9d72a6159a7c3.jpg",
      "tag": "\u82f1\u5f0f\u6447\u6eda,\u6447\u6eda,George Harrison,John Lennon",
      "desc": "\u5982\u679c\u4f60\u4e5f\u559c\u6b22\u82f1\u5f0f\u6447\u6eda......",
      "pic_w300": "http:\/\/b.hiphotos.baidu.com\/ting\/pic\/item\/e850352ac65c103820d51c82b5119313b17e89c3.jpg",
      "width": "475",
      "height": "475"
    },
    {
      "listid": "5087",
      "listenum": "393432",
      "collectnum": "4461",
      "title": "\u62c9\u4e01\u5929\u540e-\u590f\u5947\u62c9",
      "pic_300": "http:\/\/a.hiphotos.baidu.com\/ting\/pic\/item\/d6ca7bcb0a46f21f780b1172f2246b600c33aed0.jpg",
      "tag": "\u62c9\u4e01,\u821e\u66f2,\u590f\u5947\u62c9,\u6b27\u7f8e",
      "desc": "\u5728\u590f\u5947\u62c9\u7684\u4f5c\u54c1\u4e2d\uff0c\u4e0d\u4ec5\u80fd\u611f\u53d7\u5230\u6d53\u90c1\u70ed\u70c8\u7684\u62c9\u4e01\u98ce\u60c5\uff0c\u66f4\u80fd\u4f53\u4f1a\u5230\u5176\u4e2d\u8574\u85cf\u7740\u7684\u5145\u6ee1\u4fb5\u7565\u6027\u7684\u6447\u6eda\u5143\u7d20\u3002\u5728\u5979\u7684\u97f3\u4e50\u4e2d\u65f6\u5e38\u80fd\u542c\u5230\u4e00\u4e9b\u5e26\u7740\u6d53\u70c8\u4e2d\u4e1c\u8272\u5f69\u7684\u4f5c\u54c1\uff0c\u4f7f\u5979\u7684\u66f2\u98ce\u53c8\u591a\u4e86\u4e9b\u8bb8\u5f02\u57df\u98ce\u60c5\u3002",
      "pic_w300": "http:\/\/c.hiphotos.baidu.com\/ting\/pic\/item\/b8389b504fc2d5628d369fcce31190ef76c66cd0.jpg",
      "width": "600",
      "height": "632"
    }
  ]
}
```

## 
![image](https://github.com/JianwenSun/OpenMusic/blob/master/OpenMusic.Client.Wpf/Resources/Images/songlists.png)
![image](https://github.com/JianwenSun/OpenMusic/blob/master/OpenMusic.Client.Wpf/Resources/Images/songlist.png)
![image](https://github.com/JianwenSun/OpenMusic/blob/master/OpenMusic.Client.Wpf/Resources/Images/timeslider.png)

## Inject your own music api to start the player.
```csharp 
static IocInjector Build()
{
    var injector = new IocInjector();
    injector.Register<IocInjector>(injector);
    injector.Register<IClient>(BaiduClient.Guest);
    injector.Register<ICacheStorageService, CacheStorageService>();
    injector.Register<IViewModelProvider, ViewModelProvider>();
    injector.Register<ServiceProvider>(BaiduClient.Guest.ServiceProvider);
    injector.Register<PlayEngine>(new PlayEngine());
    return injector;
}
```
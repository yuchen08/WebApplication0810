using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication0810.Models.EFModels;

namespace WebApplication0810.Services;

public class TestService
{
  
    public TestService()
    {
       Table0810 tn10 = new Table0810();
       Table0811 tn11 = new Table0811();
    }

    // 取得所有資料
    public  int AddTwoNUmber(int num1,int num2)
    {
        return 1;
    }

}
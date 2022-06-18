// расчёт процентов по обычному счёту
Calculator.CalculateInterest(new AccountCommon(balance: 4000));

// расчёт процентов по зарплатному счёту
Calculator.CalculateInterest(new AccountSalary(balance: 3000));

Console.ReadLine();
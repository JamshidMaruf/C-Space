using ExpenseTracker;


Expense[] expenses = new Expense[10];

static void CreateExpense(Expense[] expenses, Expense expense, int index)
{
    expenses[index] = expense;
}

static void GetWeeklyExpense(Expense[] expenses)
{

}

static void GetMonthlyExpense(Expense[] expenses)
{

}

static void SetLimit(decimal limit)
{

}

// DateTime

DateTime time = new DateTime(2024, 12, 12);

time = time.AddHours(-1);

Console.WriteLine(time);

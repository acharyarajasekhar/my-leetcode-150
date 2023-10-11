public int MaxProfit(int[] prices) {
        var n = prices.Length;
        int profit = 0, buy = 0, i=1;
        while(i < n){
            if(prices[i-1] > prices[i]) {
                profit += prices[i-1]-prices[buy];
                buy=i;
            }
            i++;
        }
        profit += prices[i-1]-prices[buy];
        return profit;
    }

var prices = new int[] {7,1,5,3,6,4};
Console.WriteLine(MaxProfit(prices)); // 7
//*****************************************************************************
//** 1335. Minimum Difficulty of a Job Schedule  leetcode                    **
//**  Calculate the difficulty and keep the program in constraints     -Dan  **
//*****************************************************************************


int minDifficulty(int* jobDifficulty, int jobDifficultySize, int d) {
    if (jobDifficultySize < d) {
        return -1; // Not enough jobs to fill each day
    }

    int dp[jobDifficultySize + 1][d + 1];
    int maxDifficulty[jobDifficultySize + 1];

    // Initialize the DP table
    for (int i = 0; i <= jobDifficultySize; i++) {
        for (int j = 0; j <= d; j++) {
            dp[i][j] = INT_MAX;
        }
    }
    dp[0][0] = 0; // Base case: no jobs on day 0

    // Fill in the DP table
    for (int day = 1; day <= d; day++) {
        for (int i = day; i <= jobDifficultySize; i++) {
            maxDifficulty[i] = 0;
            for (int j = i; j >= day; j--) {
                maxDifficulty[i] = fmax(maxDifficulty[i], jobDifficulty[j - 1]);
                if (dp[j - 1][day - 1] != INT_MAX) {
                    dp[i][day] = fmin(dp[i][day], dp[j - 1][day - 1] + maxDifficulty[i]);
                }
            }
        }
    }

    return dp[jobDifficultySize][d] == INT_MAX ? -1 : dp[jobDifficultySize][d];
}
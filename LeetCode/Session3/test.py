def smallestSufficientTeam(req_skills, people):
        n, m = len(req_skills), len(people)
        key = {v: i for i, v in enumerate(req_skills)}
        dp = {0: []}
        for i, p in enumerate(people):
            his_skill = 0
            for skill in p:
                if skill in key:
                    his_skill |= 1 << key[skill]
            for skill_set, need in dp.items():
                with_him = skill_set | his_skill
                if with_him == skill_set: continue
                if with_him not in dp or len(dp[with_him]) > len(need) + 1:
                    dp[with_him] = need + [i]
        return dp[(1 << n) - 1]

req_skills = ["algorithms","math","java","reactjs","csharp","aws"]
people = [["algorithms","math","java"],["algorithms","math","reactjs"],["java","csharp","aws"],["reactjs","csharp"],["csharp","math"],["aws","java"]]

smallestSufficientTeam(req_skills, people)
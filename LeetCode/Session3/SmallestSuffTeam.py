from typing import List
class Solution:
    def smallestSufficientTeam(self, req_skills: List[str], people: List[List[str]]) -> List[int]:
        skillMap = dict()
        for i,skill in enumerate(req_skills):
            skillMap[skill] = 1 << i
        
        skill_person_map = {0: []}
        for i, person_skills in enumerate(people):
            skillMask = 0
            for skill in person_skills:
                skillMask |= skillMap[skill]
            
            for skillSet in list(skill_person_map):
                team = skill_person_map[skillSet]                
                with_person_skillset = skillSet | skillMask
                if with_person_skillset not in skill_person_map or len(skill_person_map[with_person_skillset]) > len(team) + 1:
                    skill_person_map[with_person_skillset] = team + [i]
        
        return skill_person_map[(1<<len(req_skills)) -1]

# req_skills = [ch for ch in "abcdefg"]
# people = [["a","b"], ["b","c"], ["d","g"], ["a","c","f","g"], ["e"], ["d"], ["a","b","c","d","e"], ["g"], ["c"]]
req_skills = ["java","nodejs","reactjs"]
people = [["java"],["nodejs"],["nodejs","reactjs"]]
ob = Solution()
print(ob.smallestSufficientTeam(req_skills, people))
from typing import List
class Solution:
    def videoStitching(self, clips, T):
        clips = sorted(clips)        
        count, curEnd, i = 0, 0, 0
        while i < len(clips):            
            # return - 1 if there is a gap
            if clips[i][0] > curEnd:
                return -1

            maxEnd = curEnd
            while i < len(clips) and clips[i][0] <= curEnd:                
                maxEnd = max(maxEnd, clips[i][1])
                i += 1
            count += 1
            curEnd = maxEnd
            
            if curEnd >= T:
                return count            
        return -1    
        

ob = Solution()
clips = [[0,2],[4,6],[8,10],[1,9],[1,5],[5,9]]
T = 10
print(ob.videoStitching(clips, T))

clips = [[0,1],[1,2]]
T = 5
print(ob.videoStitching(clips, T))

clips = [[0,1],[6,8],[0,2],[5,6],[0,4],[0,3],[6,7],[1,3],[4,7],[1,4],[2,5],[2,6],[3,4],[4,5],[5,7],[6,9]]
T = 9
print(ob.videoStitching(clips, T))

clips = [[0,4],[2,8]]
T = 5
print(ob.videoStitching(clips, T))

clips = [[0,2],[4,8]]
T = 5
print(ob.videoStitching(clips, T))


clips = [[0,2],[4,6],[8,10],[1,9],[1,5],[5,9]]
T= 10
print(ob.videoStitching(clips, T))

clips = [[0,1],[6,8],[0,2],[5,6],[0,4],[0,3],[6,7],[1,3],[4,7],[1,4],[2,5],[2,6],[3,4],[4,5],[5,7],[6,9]]
T = 9
print(ob.videoStitching(clips, T))
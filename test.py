import collections
import math

def timeInWords(h, m):
    if m == 0:
        return getNumInWords(h) + " o' clock"
    if m <= 30:        
        return getMinInWords(m) + " past " + getNumInWords(h)
    else:        
        return getMinInWords(60 - m) + " to " + getNumInWords(h + 1)
   
def getNumInWords(num):
    numInWords = {1: 'one', 2: 'two', 3: 'three', 4: 'four', 5: 'five',
                  6: 'six', 7: 'seven', 8: 'eight', 9: 'nine', 10: 'ten',
                  11: 'eleven', 12: 'twelve', 13: 'thirteen', 14: 'fourteen',
                  15: 'quarter', 16: 'sixteen', 17: 'seventeen', 18: 'eighteen',
                  19: 'nineteen', 20: 'twenty', 21: 'twenty one', 22: 'twenty two',
                  23: 'twenty three', 24: 'twenty four', 25: 'twenty five',
                  26: 'twenty six', 27: 'twenty seven', 28: 'twenty eight',
                  29: 'twenty nine', 30: 'half'}
    return numInWords[num]

def getMinInWords(min):
    if min == 1:
        return "one minute"
    if min == 15:
        return "quarter"
    if min == 30:
        return "half"
    return getNumInWords(min) + " minutes"

print(timeInWords(1,1))
#print(beautifulTriplets(1, nums))

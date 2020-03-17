def popularNFeatures(numFeatures, topFeatures, possibleFeatures, 
                     numFeatureRequests, featureRequests):
    # we first convert everything to lowercase for consistent processing
    featureRequests = [feature.lower() for feature in featureRequests]
    possibleFeatures = [possible.lower() for possible in possibleFeatures]
    print(featureRequests)
    print(possibleFeatures)
    
    featureCountDict = dict()
    for featureRequest in featureRequests:
        featureDict = getFeaturesFromRequest(featureRequest, possibleFeatures)
        for key in featureDict.keys():
            if key not in featureCountDict:
                featureCountDict[key] = 0
            featureCountDict[key] += featureDict[key]
    print(featureCountDict)
    
    # sort the List by value and then by key alphabetically
    sortedDict = sorted(featureCountDict.items(), key=lambda k: (k[1], k[0]), reverse=True)
    print(sortedDict)
    
    topFeatures = sortedDict[:topFeatures]
    topFeatures = [tup[0] for tup in topFeatures]
    print(topFeatures)
    return topFeatures

def getFeaturesFromRequest(featureRequest, listOfFeatures):
    featureDict = dict()
    for feature in listOfFeatures:
        if feature in featureRequest:
            featureDict[feature] = 1
    print(featureDict)
    return featureDict

possibleFeautres = ['anacell', 'betacellular', 'cetracular', 'deltacellular', 'eurocell']
featureRequests = ['Best service by anacell', 'betacElluLar', 'anacell provides much better than all other']
popularNFeatures(5,2,possibleFeautres,5,featureRequests)
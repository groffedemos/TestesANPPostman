if (pm.iterationData.get("peso") != undefined)
    pm.collectionVariables.set("peso", pm.iterationData.get("peso"));
else
    pm.collectionVariables.set("peso", -9999999);

if (pm.iterationData.get("altura") != undefined)
    pm.collectionVariables.set("altura", pm.iterationData.get("altura"));
else
    pm.collectionVariables.set("altura", -9999999);

if (pm.iterationData.get("imc") != undefined)
    pm.collectionVariables.set("imc", pm.iterationData.get("imc"));
else
    pm.collectionVariables.set("imc", -9999999);

if (pm.iterationData.get("situacao") != undefined)
    pm.collectionVariables.set("situacao", pm.iterationData.get("situacao"));
else
    pm.collectionVariables.set("situacao", "Indefinida");
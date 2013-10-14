

aJsonObject *createMessage(double values[], const char* keys[], int length)
{
  aJsonObject *msg = aJson.createObject();
  aJsonObject *JKeys =  aJson.createStringArray(keys,length);
  aJsonObject *JValues = aJson.createDoubleArray(values, length);
  aJson.addItemToObject(msg, "Keys", JKeys);
  aJson.addItemToObject(msg, "Values", JValues);
  return msg;
}

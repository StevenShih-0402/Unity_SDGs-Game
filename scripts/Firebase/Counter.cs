using Firebase.Firestore;

[FirestoreData] // Дж¦м
public struct Counter
{
    //Firestore Property to store count
    [FirestoreProperty]
    public int Count { get; set; }
    
    //Firestore Property to update UpdatedBy User
    [FirestoreProperty]
    public string UpdatedBy { get; set; }
}
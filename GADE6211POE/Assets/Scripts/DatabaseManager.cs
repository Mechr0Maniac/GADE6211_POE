using CommandLine;
using Google.Cloud.Firestore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace GoogleCloudSamples
{
public class DatabaseManager 
{
    
     public static string Usage = @"Usage:
C:\> dotnet run command GADE6211_POE
Where command is one of
    add-doc-as-map
    update-create-if-missing
    add-doc-data-types
    add-simple-doc-as-entity
    set-requires-id
    add-doc-data-with-auto-id
    add-doc-data-after-auto-id
    update-doc
    update-nested-fields
    update-server-timestamp
    update-document-array
";

 private static async Task AddDocAsMap(string project,int score)
        {
            FirestoreDb db = FirestoreDb.Create(project);
            // [START fs_add_doc_as_map]
            DocumentReference docRef = db.Collection("Player").Document("Score");
            Dictionary<string, object> player = new Dictionary<string, object>
            {
                { "score", score.ToString() },
                
            };
            await docRef.SetAsync(city);
            // [END fs_add_doc_as_map]
            
        }
    private static async Task AddDocDataWithAutoId(string project,int score)
        {
            FirestoreDb db = FirestoreDb.Create(project);
            // [START fs_add_doc_data_with_auto_id]
            Dictionary<string, object> player = new Dictionary<string, object>
            {
                { "Name", score.ToString() },
                
            };
            DocumentReference addedDocRef = await db.Collection("Player").AddAsync(player);
            
            // [END fs_add_doc_data_with_auto_id]
        }
}
}

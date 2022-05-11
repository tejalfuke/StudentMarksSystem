using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentMarkAutomation.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace StudentMarkAutomation.Controllers
{
    public class StudentController : Controller
    {
        public ActionResult Index()
        {
            return View("StudentView");
        }
        public ActionResult Details(int id)
        {
            return View();
        }
        public ActionResult StudentView()
        {
            return View(new Student());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult StudentView(Student student)
        {
            try
            {
                string attendStr = Newtonsoft.Json.JsonConvert.SerializeObject(student);
                string conStr = "DefaultEndpointsProtocol=https;AccountName=usethisforeverything;AccountKey=LIYwSchOA18OsJHB7dXL5hjuojyRYTlim3WG7GqSNWJdehPm5z1xE5ipy/HA/CpERYfDQ7DtkrWW/JqdM2OQHA==;EndpointSuffix=core.windows.net";

                try
                {
                    UploadBlob(conStr, attendStr, "testing", true);
                    ViewBag.MessageToScreent = "Details Updated to Blob :" + attendStr;
                }
                catch (Exception ex)
                {
                    ViewBag.MessageToScreent = "Failed to update blob " + ex.Message;
                }

                return View("StudentView");
            }
            catch
            {
                return View("StudentView");
            }
        }
        public static string UploadBlob(string conStr, string fileContent, string containerName, bool isAppend = false)
        {
            //[{w.v.f.newdata,newdata}]

            ///
            string result = "Success";
            try
            {
                //string containerName = "sample1";
                string fileName, existingContent;
                BlobClient blobClient;
                SetVariables(conStr, containerName, out fileName, out existingContent, out blobClient);

                if (isAppend)
                {
                    string fillerStart = "";
                    string fillerEnd = "]";
                    existingContent = GetContentFromBlob(conStr, fileName, containerName);
                    if (string.IsNullOrEmpty(existingContent.Trim()))
                    {
                        fillerStart = "[";
                        fileContent = fillerStart + existingContent + fileContent + fillerEnd;

                    }
                    else
                    {
                        existingContent = existingContent.Substring(0, existingContent.Length - 3);
                        fileContent = fillerStart + existingContent + "," + fileContent + fillerEnd;
                    }
                }

                var ms = new MemoryStream();
                TextWriter tw = new StreamWriter(ms);
                tw.Write(fileContent);
                tw.Flush();
                ms.Position = 0;

                blobClient.UploadAsync(ms, true);

            }
            catch (Exception ex)
            {

                result = "Failed";
                throw ex;
            }
            return result;
        }

        private static void SetVariables(string conStr, string containerName, out string fileName, out string existingContent, out BlobClient blobClient)
        {
            var serviceClient = new BlobServiceClient(conStr);
            var containerClient = serviceClient.GetBlobContainerClient(containerName);

            fileName = "data.txt";
            existingContent = "";
            blobClient = containerClient.GetBlobClient(fileName);
        }

        private static string GetContentFromBlob(string conStr, string fileName, string containerName)
        {
            BlobServiceClient blobServiceClient = new BlobServiceClient(conStr);
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            BlobClient blobClient = containerClient.GetBlobClient(fileName);
            string line = string.Empty;
            if (blobClient.Exists())
            {
                var response = blobClient.Download();
                using (var streamReader = new StreamReader(response.Value.Content))
                {
                    while (!streamReader.EndOfStream)
                    {
                        line += streamReader.ReadLine() + Environment.NewLine;
                    }
                }
            }
            return line;
        }
        public ActionResult Edit(int id)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }




    }
}

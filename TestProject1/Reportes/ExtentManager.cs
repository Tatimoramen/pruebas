using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace Reportes
{
    public static class ExtentManager
    {
        private static ExtentReports _extent;
        private static ExtentHtmlReporter _htmlReporter;

        public static ExtentReports GetExtent()
        {
            if (_extent == null)
            {
                string reportPath = Path.Combine(Directory.GetCurrentDirectory(), "Reports", "TestReport.html");
                Directory.CreateDirectory(Path.GetDirectoryName(reportPath)!);

                _htmlReporter = new ExtentHtmlReporter(reportPath);
                _extent = new ExtentReports();
                _extent.AttachReporter(_htmlReporter);
            }
            return _extent;
        }
    }
}

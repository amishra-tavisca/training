<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:output method="html" indent="yes" />
  <xsl:template match="/">
    <body>
      <xsl:apply-templates select="/*[local-name()='TestRun']" />
    </body>
  </xsl:template>
  <!--Display test run summary-->
  <xsl:template match="/*[local-name()='TestRun']">
    <div style="font-family:arial,helvetica,sans-serif;font-size:11px;max-width:1800px;word-wrap: break-word;">
      <h1>
        Test Run: <xsl:value-of select="@name" /></h1>
      <h2>Summary</h2>
      <p>
        Designated outcome :
        <xsl:choose><xsl:when test="*[local-name()='ResultSummary']/@outcome ='Passed'"><span style="color: forestGreen; font-weight: bold;"><xsl:value-of select="*[local-name()='ResultSummary']/@outcome" /></span></xsl:when><xsl:otherwise><span style="color: Red; font-weight: bold;"><xsl:value-of select="*[local-name()='ResultSummary']/@outcome" /></span></xsl:otherwise></xsl:choose></p>
      <div style="display:table;border:1px solid #333;width:92%;font-size:16px;font-weight:bold;">
        <div style="text-align: center;display:table-row;">
          <div style="display:table-cell;border:1px solid #333;width:20%;">
            Number of Tests
          </div>
          <div style="display: table-cell;border: 1px solid #333;padding:10px;background-color: #53c400;color: black;width:16%;">
            Passed
          </div>
          <div style="display:table-cell;border:1px solid #333;padding:10px;background-color: #e82a2e; color: black;width:16%;">
            Failed
          </div>
          <div style="display:table-cell;border:1px solid #333;padding:10px;background-color: yellow; color:black;width:16%;">
            Inconclusive
          </div>
          <div style="display:table-cell;border:1px solid #333;padding:10px;background-color: firebrick; color: black;width:16%;">
            Aborted
          </div>
          <div style="display:table-cell;border:1px solid #333;padding:10px;background-color: #33CCFF; color: black;width:16%;">
            Timeout
          </div>
        </div>
        <div style="text-align: center;display:table-row;font-size:14px;">
          <div style="display:table-cell;padding:5px;border:1px solid #333;">
            <xsl:value-of select="*[local-name()='ResultSummary']//*[local-name()='Counters']/@total" />
          </div>
          <div style="display:table-cell;padding:5px;border:1px solid #333;">
            <xsl:value-of select="*[local-name()='ResultSummary']//*[local-name()='Counters']/@passed" />
          </div>
          <div style="display:table-cell;padding:5px;border:1px solid #333;">
            <xsl:value-of select="*[local-name()='ResultSummary']//*[local-name()='Counters']/@failed" />
          </div>
          <div style="display:table-cell;padding:5px;border:1px solid #333;">
            <xsl:value-of select="*[local-name()='ResultSummary']//*[local-name()='Counters']/@inconclusive" />
          </div>
          <div style="display:table-cell;padding:5px;border:1px solid #333;">
            <xsl:value-of select="*[local-name()='ResultSummary']//*[local-name()='Counters']/@aborted" />
          </div>
          <div style="display:table-cell;padding:5px;border:1px solid #333;">
            <xsl:value-of select="*[local-name()='ResultSummary']//*[local-name()='Counters']/@timeout" />
          </div>
        </div>
      </div>
      <!--Display any errors and warnings-->
      <xsl:variable name="runinfos" select="*[local-name()='ResultSummary']/*[local-name()='RunInfos']/*[local-name()='RunInfo']" />
      <xsl:if test="count($runinfos) &gt; 0">
        <span style="font-size:18px;font-weight:bold;">Errors and Warnings</span>
        <div style="display:table;border:1px solid #333;width:92%;">
          <xsl:apply-templates select="$runinfos" />
        </div>
      </xsl:if>
      <xsl:apply-templates select="*[local-name()='Results']" mode="Failed"></xsl:apply-templates>
      <xsl:apply-templates select="*[local-name()='Results']" mode="Passed"></xsl:apply-templates>
      <xsl:apply-templates select="*[local-name()='Results']" mode="Others"></xsl:apply-templates>
    </div>
  </xsl:template>
  <!--Display test run info-->
  <xsl:template match="*[local-name()='RunInfo']">
    <div style="text-align: left;display:table-row;font-family:consolas,courier;">
      <div style="display:table-cell;border:1px solid #333;padding:5px;">
        <xsl:apply-templates select="*" />
      </div>
    </div>
  </xsl:template>
  <!--Display passing tests table-->
  <xsl:template match="*[local-name()='Results']" mode="Passed">
    <h2 style="font-size:18px;font-weight:bold;padding-top:20px;">Passing Tests</h2>
    <div style="display:table;border:2px solid #333;border-bottom:1px solid #333;font-size:small;width:92%;">
      <div style="text-align: center;display:table-row;font-size: 16px; font-weight:bold;background-color:#E0DFDB;">
        <div style="display:table-cell;border:1px solid #333;border-top:none;border-left:none;padding: 5px 25px 5px 25px;width:50px;max-width:100px;">Test Result</div>
        <div style="display:table-cell;border:1px solid #333;border-top:none;padding:5px;width:400px;max-width:420px;">Test Name</div>
        <div style="display:table-cell;border:1px solid #333;border-top:none;padding: 5px 25px 5px 25px;width:50px;max-width:120px;">Test Duration</div>
        <div style="display:table-cell;border:1px solid #333;border-top:none;border-right:none;padding: 5px 25px 5px 25px;max-width:920px;">Acceptance Criteria</div>
      </div>
      <xsl:apply-templates select="./*" mode="Passed" />
    </div>
  </xsl:template>
  <!--Display failing tests table-->
  <xsl:template match="*[local-name()='Results']" mode="Failed">
    <h2 style="font-size:18px;font-weight:bold;padding-top:20px;">Failing Tests</h2>
    <div style="display:table;border:2px solid #333;border-bottom:1px solid #333;font-size:small;width:92%;">
      <div style="text-align: center;display:table-row;font-size: 16px; font-weight:bold;background-color:#E0DFDB;">
        <div style="display:table-cell;border:1px solid #333;border-top:none;border-left:none;padding: 5px 25px 5px 25px;width:50px;max-width:100px;">Test Result</div>
        <div style="display:table-cell;border:1px solid #333;border-top:none;padding:5px;width:400px;max-width:420px;">Test Name</div>
        <div style="display:table-cell;border:1px solid #333;border-top:none;padding: 5px 25px 5px 25px;width:50px;max-width:120px;">Test Duration</div>
        <div style="display:table-cell;border:1px solid #333;border-top:none;border-right:none;padding: 5px 25px 5px 25px;max-width:920px;">Test Run Details</div>
      </div>
      <xsl:apply-templates select="./*" mode="Failed" />
    </div>
  </xsl:template>
  <!--Display other tests table-->
  <xsl:template match="*[local-name()='Results']" mode="Others">
    <h2 style="font-size:18px;font-weight:bold;padding-top:20px;">Other Tests</h2>
    <div style="display:table;border:2px solid #333;border-bottom:1px solid #333;font-size:small;width:92%;">
      <div style="text-align: center;display:table-row;font-size: 16px; font-weight:bold;background-color:#E0DFDB;">
        <div style="display:table-cell;border:1px solid #333;border-top:none;border-left:none;padding: 5px 25px 5px 25px;width:50px;max-width:100px;">Test Result</div>
        <div style="display:table-cell;border:1px solid #333;border-top:none;padding:5px;width:400px;max-width:420px;">Test Name</div>
        <div style="display:table-cell;border:1px solid #333;border-top:none;border-right:none;padding: 5px 25px 5px 25px;width:50px;max-width:120px;">Test Duration</div>
      </div>
      <xsl:apply-templates select="./*" mode="Others" />
    </div>
  </xsl:template>
  <!--Display test result for passing tests-->
  <xsl:template match="*[local-name()='UnitTestResult']" mode="Passed">
    <xsl:choose>
      <xsl:when test="@outcome = 'Passed'">
        <div style="display:table-row;">
          <div style="display:table-cell;padding:5px;border:1px solid #333;border-left:none;text-align: center; font-weight: bold; background-color: #53c400;">
            <xsl:value-of select="@outcome" />
          </div>
          <div style="display:table-cell;border:1px solid #333;padding:10px; font-size:14px;font-weight:bold;">
            <xsl:value-of select="@testName" />
          </div>
          <div style="display:table-cell;padding:5px;border:1px solid #333;text-align: right;">
            <xsl:value-of select="@duration" />
          </div>
          <div style="display:table-cell;padding:5px;border:1px solid #333;border-right:none;text-align:left;">
            <xsl:call-template name="ListAcceptanceCriteria"></xsl:call-template>
          </div>
        </div>
      </xsl:when>
    </xsl:choose>
  </xsl:template>
  <!--Display test result for failing tests-->
  <xsl:template match="*[local-name()='UnitTestResult']" mode="Failed">
    <xsl:choose>
      <xsl:when test="@outcome = 'Failed'">
        <div style="display:table-row;">
          <div style="display:table-cell;padding:5px;border:1px solid #333;border-left:none;text-align: center; font-weight: bold; background-color: #e82a2e;">
            <xsl:value-of select="@outcome" />
          </div>
          <div style="display:table-cell;border:1px solid #333;padding:10px; font-size:14px;font-weight:bold;">
            <xsl:value-of select="@testName" />
          </div>
          <div style="display:table-cell;padding:5px;border:1px solid #333;text-align: right;">
            <xsl:value-of select="@duration" />
          </div>
          <div style="display:table-cell;border:1px solid #333;border-right:none;text-align: left;">
            <xsl:call-template name="TestRunDetails" />
          </div>
        </div>
      </xsl:when>
    </xsl:choose>
  </xsl:template>
  <!--Display the test result for other tests-->
  <xsl:template match="*[local-name()='UnitTestResult']" mode="Others">
    <xsl:choose>
      <xsl:when test="@outcome = 'Passed'"></xsl:when>
      <xsl:when test="@outcome = 'Failed'"></xsl:when>
      <xsl:otherwise>
        <div style="display:table-row;">
          <xsl:choose>
            <xsl:when test="@outcome = 'Inconclusive'">
              <div style="display:table-cell;padding:5px;border:1px solid #333;border-left:none;text-align: center; font-weight: bold; background-color: yellow; color: black;">
                <xsl:value-of select="@outcome" />
              </div>
            </xsl:when>
            <xsl:otherwise>
              <div style="display:table-cell;padding:5px;border:1px solid #333;border-left:none;text-align: center; font-weight: bold; background-color: lightblue; color: black; ">
                <xsl:value-of select="@outcome" />
              </div>
            </xsl:otherwise>
          </xsl:choose>
          <div style="display:table-cell;border:1px solid #333;padding:10px; font-size:14px;font-weight:bold;">
            <xsl:value-of select="@testName" />
          </div>
          <div style="display:table-cell;padding:5px;border:1px solid #333;text-align: right;">
            <xsl:value-of select="@duration" />
          </div>
        </div>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>
  <!--Display test run details-->
  <xsl:template name="TestRunDetails">
    <details>
      <summary style="display:block;padding:5px; font-weight:bold; cursor:pointer; font-size:14px;">
        Test Run Details
      </summary>
      <div style="display:table;line-height:22px;width:100%;">
        <xsl:choose>
          <xsl:when test="@resultType = 'DataDrivenTest'">
            <!--For data driven tests, we have to iterate over each inner test-->
            <xsl:for-each select="./*[local-name()='InnerResults']/*[local-name()='UnitTestResult']">
              <xsl:choose>
                <xsl:when test="@outcome = 'Failed'">
                  <div style="display:table-row;background-color:#fdb1b1;font-size:13px;">
                    <xsl:call-template name="IndividualTestDetails"></xsl:call-template>
                    <xsl:apply-templates select="./*[local-name()='Output']/*[local-name()='ErrorInfo']" />
                  </div>
                </xsl:when>
                <xsl:when test="@outcome = 'Passed'">
                  <div style="display:table-row;background-color:#BCE937;font-size:13px;">
                    <xsl:call-template name="IndividualTestDetails"></xsl:call-template>
                    <div style="display:table-cell;font-size:13px;padding:5px;border-top:1px solid #333;">
                      This test has passed
                    </div>
                  </div>
                </xsl:when>
                <xsl:otherwise></xsl:otherwise>
              </xsl:choose>
            </xsl:for-each>
          </xsl:when>
          <xsl:otherwise>
            <!--For regular unit tests, no such iteration is required-->
            <xsl:for-each select=".">
              <xsl:choose>
                <xsl:when test="@outcome = 'Failed'">
                  <div style="display:table-row;background-color:#fdb1b1;font-size:13px;">
                    <xsl:call-template name="IndividualTestDetails"></xsl:call-template>
                    <xsl:apply-templates select="./*[local-name()='Output']/*[local-name()='ErrorInfo']" />
                  </div>
                </xsl:when>
                <xsl:when test="@outcome = 'Passed'">
                  <div style="display:table-row;background-color:#BCE937;font-size:13px;">
                    <xsl:call-template name="IndividualTestDetails"></xsl:call-template>
                    <div style="display:table-cell;font-size:13px;padding:5px;border-top:1px solid #333;">
                      This test has passed
                    </div>
                  </div>
                </xsl:when>
                <xsl:otherwise></xsl:otherwise>
              </xsl:choose>
            </xsl:for-each>
          </xsl:otherwise>
        </xsl:choose>
      </div>

      
    </details>
  </xsl:template>
  <!--Display details of an individual test-->
  <xsl:template name="IndividualTestDetails">
    <div style="display:table-cell;border-right:1px solid #333;border-top:1px solid #333;min-width:400px;width:400px;max-width:400px;padding:5px;">
      <xsl:value-of select="position()" />.
      <span style="font-weight: bold;">Acceptance Criteria: </span>
      <xsl:value-of select="./*[local-name()='Output']/*[local-name()='StdOut']" />
      <br />
      <span>Captured Images:</span>      
        <xsl:for-each select="./*[local-name()='ResultFiles']/*[local-name()='ResultFile']">
          <span>
            <xsl:value-of select="@path" />
          </span>
          <br />
        </xsl:for-each>      
    </div>
    <!--<div style="display:table-cell;padding:5px;border-right:1px solid #333;min-width:80px;width:80px;max-width:80px;">
      <span style="font-weight: bold;">Result: </span>
      <xsl:choose>
        <xsl:when test="@outcome = 'Passed'">
          <b style="color:#006600">
            <xsl:value-of select="@outcome" />
          </b>
        </xsl:when>
        <xsl:when test="@outcome = 'Failed'">
          <b style="color:#FF0000">
            <xsl:value-of select="@outcome" />
          </b>
        </xsl:when>
        <xsl:otherwise>
          <span style="font-weight: bold;">
            <xsl:value-of select="@outcome" />
          </span>
        </xsl:otherwise>
      </xsl:choose>
    </div>-->
  </xsl:template>
  <!--List out acceptance criteria for a test-->
  <xsl:template name="ListAcceptanceCriteria">
    <div>
      <details>
        <summary style="display:block;padding:5px; font-weight:bold; cursor:pointer; font-size:14px;">
          Acceptance criteria
        </summary>
        <xsl:choose>
          <xsl:when test="@resultType = 'DataDrivenTest'">
            <!--For data driven tests, we have to iterate over each inner test-->
            <xsl:for-each select="./*[local-name()='InnerResults']/*[local-name()='UnitTestResult']">
              <div style="padding:5px;">
                <xsl:value-of select="position()" />.
                <xsl:value-of select="./*[local-name()='Output']/*[local-name()='StdOut']" /></div>
            </xsl:for-each>
          </xsl:when>
          <xsl:otherwise>
            <!--For regular unit tests, no such iteration is required-->
            <xsl:for-each select=".">
              <div style="padding:5px;">
                <xsl:value-of select="position()" />.
                <xsl:value-of select="./*[local-name()='Output']/*[local-name()='StdOut']" /></div>
            </xsl:for-each>
          </xsl:otherwise>
        </xsl:choose>
      </details>
    </div>
  </xsl:template>
  <!--Display the error information-->
  <xsl:template match="*[local-name()='ErrorInfo']">
    <div style="display:table-cell;font-size:13px;border-top:1px solid #333;padding:5px;min-width:350px;width:350px;max-width:350px;">
      <span style="font-weight: bold;">Error Info:</span>
      <br />
      <xsl:value-of select="./*[local-name()='Message']" />
      <br />
      <details>
        <summary style="cursor:pointer;">View Stack Trace</summary>
        <div>
          <xsl:value-of select="./*[local-name()='StackTrace']" />
        </div>
      </details>
    </div>
  </xsl:template>
</xsl:stylesheet>
// 連到後端的伺服器
var backURL = "https://localhost:7243";

// (WebAPI) GET Machine 列表。
async function API_GetMachineList() {
  // 建立 URL
  const apiURL = backURL + "/api/Mechine";

  // 設定 CRUD
  const option = {
    method: "GET",
  };

  // 執行 WebAPI 呼叫
  return await _getUrldata(apiURL, option);
}

// (WebAPI) DELECT Machine 列表。
async function API_DeleteMachine(machinID) {
  // 建立 URL
  const apiURL = backURL + `/api/Mechine/${machinID}`;

  // 設定 CRUD
  const option = {
    method: "DELETE",
  };

  // 執行 WebAPI 呼叫
  return await _getUrldata(apiURL, option);
}

// (WebAPI) POST Machine 列表。
async function API_AddMachine(name, place) {
  // 建立 JSON 格式
  const paramater = {
    Name: name,
    place: place,
  };

  // 建立 URL
  const apiURL = backURL + "/api/Mechine";

  // 設定 CRUD
  const option = {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(paramater),
  };
  // 執行 WebAPI 呼叫
  return await _getUrldata(apiURL, option);
}

// (WebAPI) GET Project 列表。
async function API_GetProjectList() {
  // 建立 URL
  const apiURL = backURL + "/api/Project";

  // 設定 CRUD
  const option = {
    method: "GET",
  };

  // 執行 WebAPI 呼叫
  return await _getUrldata(apiURL, option);
}

// (WebAPI) 根據使用者提供的 projectID 去取得該 Project 的數值。
async function API_GetData(projID) {
  // 建立URL
  const apiURL = backURL + `/api/Data/${projID}`;

  // 設定CRUD
  const option = {
    method: "GET",
  };

  // 執行 WebAPI 呼叫
  return await _getUrldata(apiURL, option);
}

// (WebAPI) 上傳該 MechineID 的數值。
async function API_UploadCSV(machineID, csvfile) {
  // 將檔案打包進 FromData 內
  const formData = new FormData();
  formData.append("file", csvfile);

  // 建立URL
  const apiUrl = backURL + `/api/Project/${machineID}`;
  console.log(apiUrl);

  // 上傳路徑
  var options = {
    method: "POST",
    body: formData,
  };

  // 執行 WebAPI 呼叫
  return await _getUrldata(apiUrl, options);
}

// (WebAPI) 根據使用者提供的 projectID 去刪除該 Project 的數值。
async function API_DeleteProject(projID) {
  // 建立URL
  const apiURL = backURL + `/api/Project/${projID}`;

  // 設定CRUD
  const option = {
    method: "DELETE",
  };

  // 執行 WebAPI 呼叫
  return await _getUrldata(apiURL, option);
}

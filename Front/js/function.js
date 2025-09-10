//#region Web API

async function _getUrldata(apiUrl, options) {
  // 使用 fetch 函式擷取資料
  const response = await fetch(apiUrl, options);

  // 這裡可以處理 HTTP 錯誤（例如404, 500）
  if (!response.ok) {
    const errorText = await response.text();
    return { error: true, status: response.status, message: errorText };
  }

  // 檢查回應的 Content-Type
  const contentType = response.headers.get("content-type");
  if (contentType) {
    if (contentType.indexOf("application/json") !== -1) {
      // 如果是 JSON 格式的回應，解析為 JSON 物件
      return response.json();
    } else if (contentType.indexOf("text/plain") !== -1) {
      // 如果是純文字，取得純文字資料
      return response.text();
    } else {
      // 否則，回傳 Blob 資料
      return response.blob();
    }
  } else {
    // 如果無法判斷 Content-Type，回傳 Blob 資料
    return response.blob();
  }
}

//#endregion

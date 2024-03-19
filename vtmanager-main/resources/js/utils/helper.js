import {
  DATE_FORMAT_SLASH,
  VALIDATE_TYPE,
  ROUTER,
  ROUTER_NAME,
  SEARCH_STATE,
} from "@/constants";
import moment from "moment/moment";

const checkValidDate = (date, format = DATE_FORMAT_SLASH) => {
  if (date && moment(date).isValid()) {
    return moment(date).format(format);
  } else {
    return "";
  }
};

const convertTime = (time) => {
  let position = 2;
  let character = "：";
  if (time?.length === 4) {
    return time.slice(0, position) + character + time.slice(position);
  }
  return time;
};

const checkBlank = (string) => {
  switch (string) {
    case "":
    case null:
    case undefined:
    case "undefined":
    case "null":
      return true;
    default:
      return false;
  }
};

const checkMaxLenght = (str, maxLenght) => {
  return str.length <= maxLenght;
};

const checkMinLenght = (str, maxLenght) => {
  return str.length >= maxLenght;
};

const checkAlphanumeric = (str) => {
  const alphanumericRegex = /^[a-zA-Z0-9]+$/;
  return alphanumericRegex.test(str);
};

const checkNumeric = (num) => {
  const alphanumericRegex = /^[0-9]+$/;
  return alphanumericRegex.test(num);
};

const validate = (app, validations) => {
  let validationResult = null;
  for (let i = 0; i < validations.length; i++) {
    const { name, label, value, checks } = validations[i];

    for (let j = 0; j < checks.length; j++) {
      const { type, max, min } = checks[j];
      let message = "";

      switch (type) {
        case VALIDATE_TYPE.REQUIRED:
          if (checkBlank(value)) {
            message = app.$t("validate.required");
          }
          break;

        case VALIDATE_TYPE.LENGTH:
          if (max && value && !checkMaxLenght(value, max)) {
            message = app.$t("validate.maxLength");
            break;
          }
          if (min && value && !checkMinLenght(value, min)) {
            message = app.$t("validate.minLength");
            break;
          }
          break;

        case VALIDATE_TYPE.ALPPHA_NUM:
          if (!checkAlphanumeric(value)) {
            message = app.$t("validate.alpha_num");
          }
          break;

        case VALIDATE_TYPE.NUM:
          if (!checkNumeric(value)) {
            message = app.$t("validate.numberic");
          }
          break;
      }

      if (!checkBlank(message)) {
        validationResult = {
          name: name,
          message: message.replace(":attribute", label),
        };
        break;
      }
    }

    if (validationResult) break;
  }

  return validationResult;
};

const customerValidate = (app, values) => {
  const validations = [
    {
      name: "customerCode",
      label: app.label.customerCode,
      value: values.customer_code,
      checks: [
        { type: VALIDATE_TYPE.REQUIRED },
        { type: VALIDATE_TYPE.LENGTH, max: 20 },
        { type: VALIDATE_TYPE.ALPPHA_NUM },
      ],
    },
    {
      name: "customerName",
      label: app.label.customerName,
      value: values.customer_name,
      checks: [
        { type: VALIDATE_TYPE.REQUIRED },
        { type: VALIDATE_TYPE.LENGTH, max: 100 },
      ],
    },
    {
      name: "creditLimit",
      label: app.label.creditLimit,
      value: values.credit_limit,
      checks: [{ type: VALIDATE_TYPE.NUM }],
    },
    {
      name: "paymentSite",
      label: app.label.paymentSite,
      value: values.payment_site,
      checks: [{ type: VALIDATE_TYPE.NUM }],
    },
  ];

  return validate(app, validations);
};

const showMessage = (app, customError) => {
  app.messageError = customError?.message;
  app.$refs[customError?.name].focus();
};

const convertToCamelCase = (inputString) => {
  if (!checkBlank(inputString)) {
    const words = inputString.split("_");
    const capitalizedWords = words.map((word, index) => {
      if (index === 0) {
        return word;
      }
      return word.charAt(0).toUpperCase() + word.slice(1);
    });

    return capitalizedWords.join("");
  }
  return "";
};

const convertToSnakeCase = (inputString) => {
  return inputString.replace(/([a-z])([A-Z])/g, "$1_$2").toLowerCase();
};

const convertObjectToSnakeCase = (obj) => {
  const snakeCaseObj = {};
  for (const key in obj) {
    if (Object.prototype.hasOwnProperty.call(obj, key)) {
      const snakeCaseKey = key.replace(
        /[A-Z]/g,
        (match) => `_${match.toLowerCase()}`
      );
      snakeCaseObj[snakeCaseKey] = obj[key];
    }
  }
  return snakeCaseObj;
};

const handleBackButton = (app) => {
  const screenName = app.$route.name;

  // Clear condition search
  const { MstCustomerMaster, OmsOrderInquiry } = ROUTER_NAME;
  switch (screenName) {
    case MstCustomerMaster:
      localStorage.setItem(MstCustomerMaster, null);
      break;
    case OmsOrderInquiry:
      localStorage.setItem(OmsOrderInquiry, null);
      break;
  }

  // Back to Main screen or orther screen
  const previousPathLocal = localStorage.getItem("previousPath");
  const previousPath =
    checkBlank(app.$router?.params?.isMenu) || checkBlank(previousPathLocal)
      ? ROUTER?.ComMain?.path
      : previousPathLocal;
  app.$router.push(previousPath);
};

const handleConditionSearch = (app, searchState) => {
  const screenName = app.$route.name;
  const { MstCustomerMaster, OmsOrderInquiry } = ROUTER_NAME;

  switch (screenName) {
    case MstCustomerMaster:
      localStorage.setItem(
        MstCustomerMaster,
        JSON.stringify({
          customerCode:
            searchState === SEARCH_STATE.ADD_CONDITION
              ? app?.conditionSearch?.customerCode
              : "",
          customerName:
            searchState === SEARCH_STATE.ADD_CONDITION
              ? app?.conditionSearch?.customerName
              : "",
        })
      );
      break;
    case OmsOrderInquiry:
      const {
        // 発注日
        orderStartDate,
        orderEndDate,
        // 納期
        specifiedDeliveryStartDate,
        specifiedDeliveryEndDate,
        // ステータス
        status,
        // 納入先名
        deliveryDestinationName,
        // 商品コード
        productCode,
        // 商品名
        productName,
        // 登録日時
        registeredDate,
        registeredTime,
        // 発注番号
        orderNumber,
      } = app?.conditionSearch;
      const searchStateAddCondition =
        searchState === SEARCH_STATE.ADD_CONDITION;

      localStorage.setItem(
        OmsOrderInquiry,
        JSON.stringify({
          // 発注日
          orderStartDate:
            searchStateAddCondition && orderStartDate
              ? moment(orderStartDate).format("YYYYMMDD")
              : "",
          orderEndDate:
            searchStateAddCondition && orderEndDate
              ? moment(orderEndDate).format("YYYYMMDD")
              : "",
          // 納期
          specifiedDeliveryStartDate:
            searchStateAddCondition && specifiedDeliveryStartDate
              ? moment(specifiedDeliveryStartDate).format("YYYYMMDD")
              : "",
          specifiedDeliveryEndDate:
            searchStateAddCondition && specifiedDeliveryEndDate
              ? moment(specifiedDeliveryEndDate).format("YYYYMMDD")
              : "",
          // ステータス
          status: searchStateAddCondition ? status : "",
          // 納入先名
          deliveryDestinationName: searchStateAddCondition
            ? deliveryDestinationName
            : "",
          // 商品コード
          productCode: searchStateAddCondition ? productCode : "",
          // 商品名
          productName: searchStateAddCondition ? productName : "",
          // 登録日時
          registeredDate: searchStateAddCondition ? registeredDate : "",
          registeredTime: searchStateAddCondition ? registeredTime : "",
          // 発注番号
          orderNumber: searchStateAddCondition ? orderNumber : "",
        })
      );
      break;
  }
};

const handlePageReload = (event, app) => {
  if (app.isOpenedFromMenu)
    localStorage.setItem("isOpenedFromMenu", app.isOpenedFromMenu);
};

const setIsOpenedFromMenu = (app) => {
  let isOpenedFromMenu = app.$route.params.isOpenedFromMenu ? true : false;
  if (!isOpenedFromMenu) {
    const isOpenedFromMenuTmp = localStorage.getItem("isOpenedFromMenu");
    localStorage.removeItem("isOpenedFromMenu");
    if (isOpenedFromMenuTmp) isOpenedFromMenu = isOpenedFromMenuTmp;
  }

  app.isOpenedFromMenu = isOpenedFromMenu;
};

export {
  checkValidDate,
  convertTime,
  checkBlank,
  validate,
  showMessage,
  customerValidate,
  convertToCamelCase,
  convertToSnakeCase,
  convertObjectToSnakeCase,
  handleBackButton,
  handleConditionSearch,
  setIsOpenedFromMenu,
  handlePageReload,
};

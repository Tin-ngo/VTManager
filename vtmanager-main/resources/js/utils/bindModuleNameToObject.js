const bindModuleNameToObject = (moduleName, obj) => {
  return Object.entries(obj).reduce((acc, [key, value]) => {
    acc[key] = `${moduleName}/${value}`

    return acc
  }, {})
}

export default bindModuleNameToObject

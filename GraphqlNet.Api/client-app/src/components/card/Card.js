export default function Card({title = '', className = '', children, ...props}) {
  return (
    <div className={`bg-white block shadow rounded-lg p-5 ${className}`} {...props}>
      {title ? <h6 className="font semibold my-3 text-gray-600">{title}</h6> : ''}
      {children}
    </div>
  )
}